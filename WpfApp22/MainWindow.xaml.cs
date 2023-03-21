using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp22
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private bool SzamokHelyesekE()

        {
            double a = 0;

            try
            {
                a = Convert.ToDouble(txtEgyikSzam.Text);

            }
            catch (FormatException)
            {
                MessageBox.Show("A szám nem megfelelő");
                txtEgyikSzam.Text = "";
                txtEgyikSzam.Focus();
                return false;
            }

            double b = 0;
            try
            {
                b = Convert.ToDouble(txtMasikSzam.Text);

            }
            catch (FormatException)
            {
                MessageBox.Show("A szám nem megfelelő");
                txtMasikSzam.Text = "";
                txtMasikSzam.Focus();
                return false;
            }
            return true;
        }

        //------------------------------------------------------------------------------------------------------------


        private void btnOsszead_Click(object sender, RoutedEventArgs e)
        {
            if (SzamokHelyesekE())
            {
                double a = Convert.ToDouble(txtEgyikSzam.Text);
                double b = Convert.ToDouble(txtMasikSzam.Text);
                double eredmeny = Math.Round(a + b, 4);
                lblEredmeny.Content = eredmeny;
                string muvelet = $"{a} + {b} = {eredmeny}";
                MuveletHozzafuzese(muvelet);
            }

        }

        private void MuveletHozzafuzese(string muvelet)
        {

            StreamWriter sw = new StreamWriter("muveletek.txt", append: true);           //  append = hozzáfűzés
            sw.WriteLine(muvelet);
            sw.Close();



            //Kivált egy kivételt--->  jelzi, hogy a metódus még nem készült el.

        }

        private void btnKivon_Click(object sender, RoutedEventArgs e)
        {
            if (SzamokHelyesekE())
            {
                double a = Convert.ToDouble(txtEgyikSzam.Text);
                double b = Convert.ToDouble(txtMasikSzam.Text);
                double eredmeny = Math.Round(a - b, 4);
                lblEredmeny.Content = eredmeny;
                string muvelet = $"{a} - {b} = {eredmeny}";
                MuveletHozzafuzese(muvelet);
            }
        }

        private void btnOszt_Click(object sender, RoutedEventArgs e)
        {
            if (SzamokHelyesekE())
            {
                double a = Convert.ToDouble(txtEgyikSzam.Text);
                double b = Convert.ToDouble(txtMasikSzam.Text);

                if (b == 0)
                {
                    MessageBox.Show("0-val nem lehet osztani.");
                }
                else
                {
                    double eredmeny = Math.Round(a / b, 4);
                    lblEredmeny.Content = eredmeny;
                    string muvelet = $"{a} / {b} = {eredmeny}";
                    MuveletHozzafuzese(muvelet);

                }
            }
        }
        private void btnSzoroz_Click(object sender, RoutedEventArgs e)
        {
            if (SzamokHelyesekE())
            {
                double a = Convert.ToDouble(txtEgyikSzam.Text);
                double b = Convert.ToDouble(txtMasikSzam.Text);
                double eredmeny = Math.Round(a * b, 4);
                lblEredmeny.Content = eredmeny;
                string muvelet = $"{a} * {b} = {eredmeny}";
                MuveletHozzafuzese(muvelet);
            }
        }

        private void btnBtolt_Click(object sender, RoutedEventArgs e)
        {
            if (txtFajlNeve.Text == "")
            {
                MessageBox.Show("Nem adott meg fájlnevet!");
                return;
            }

            lbEredmenyek.Items.Clear();
            try
            {
                StreamReader sr = new StreamReader(txtFajlNeve.Text);
                while (!sr.EndOfStream)
                {
                    lbEredmenyek.Items.Add(sr.ReadLine());
                }
                sr.Close();
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("A megadott fájl nem található!");
                return;
            }
            catch (IOException sas)
            {
                MessageBox.Show("Ismeretlen eredetű I/O hiba! \n" + sas.Message);
                return;
            }
            MessageBox.Show("Sikeres beolvasás!");

        }
    }
}
