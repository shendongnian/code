        using System;
        using System.Collections.Generic;
        using System.Collections.ObjectModel;
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
        namespace SolutionDatagrid
        {
            /// <summary>
            /// Interaction logic for MainWindow.xaml
            /// </summary>
            public partial class MainWindow : Window
            {
                public MainWindow()
                {
                    this.InitializeComponent();
                    // List of Customers
                    this.Customers = new ObservableCollection<Customer>();
                    // List of Colours
                    this.Colours = new List<string>
                    {
                        "Red", "Orange", "Yellow", "Green", "Blue", "Indigo", "Violet"
                    };
                    this.DataContext = this;
                }
                // Properties
                public List<string> Colours { get; set; }
                public ObservableCollection<Customer> Customers { get; set; }
                // Button Click Events
                private void Button_Add_Click(object sender, RoutedEventArgs e)
                {
                    // Variables to hold customer data
                    string firstName = txtFirstName.Text;
                    string lastName = txtLastName.Text;
                    string colour = cbxColor.SelectedItem.ToString();
                    // If our data is valid
                    if(firstName !=null && lastName!=null && colour!=null)
                    {
                        // Create new customer using data
                        Customer customer = new Customer { Name = firstName, Surname = lastName, Colour = colour };
                
                        // Add the new cutomer to the existing list of customers
                        this.Customers.Add(customer);
                    }
                }
                private void Button_Reset_Click(object sender, RoutedEventArgs e)
                {
                    this.Customers.Clear();
                }
            }
            // Customer Class
            public class Customer
            {
                // Properties
                public string Name { get; set; }
                public string Surname { get; set; }
                public string Colour { get; set; }
            }
        }
