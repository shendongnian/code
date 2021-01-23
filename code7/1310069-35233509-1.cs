        using System;
        using System.Collections;
        using System.Collections.Generic;
        using System.Drawing;
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
        namespace Solutions
        {
            /// <summary>
            /// Interaction logic for MainWindow.xaml
            /// </summary>
            public partial class MainWindow : Window
            {
                public MainWindow()
                {
                    this.InitializeComponent();
                    this.InitializeData();
                    this.DataContext = this;
                }
                // Customers Sample Data and Colors
                private void InitializeData() 
                {
                    // Sample Data: List of Customers
                    this.Customers = new List<Customer>
                    {
                        new Customer(){ CustomerID = 01, Code = "CST-00A-001", Name = "Name", Surname = "Surname", Telephone = "12345567890", Email = "customer@email.com"},
                        new Customer(){ CustomerID = 02, Code = "CST-00A-002", Name = "Name", Surname = "Surname", Telephone = "12345567890", Email = "customer@email.com"},
                        new Customer(){ CustomerID = 03, Code = "CST-00A-003", Name = "Name", Surname = "Surname", Telephone = "12345567890", Email = "customer@email.com"},
                        new Customer(){ CustomerID = 04, Code = "CST-00A-004", Name = "Name", Surname = "Surname", Telephone = "12345567890", Email = "customer@email.com"},
                        new Customer(){ CustomerID = 05, Code = "CST-00A-005", Name = "Name", Surname = "Surname", Telephone = "12345567890", Email = "customer@email.com"},
                        new Customer(){ CustomerID = 06, Code = "CST-00A-006", Name = "Name", Surname = "Surname", Telephone = "12345567890", Email = "customer@email.com"},
                        new Customer(){ CustomerID = 07, Code = "CST-00A-007", Name = "Name", Surname = "Surname", Telephone = "12345567890", Email = "customer@email.com"},
                        new Customer(){ CustomerID = 08, Code = "CST-00A-008", Name = "Name", Surname = "Surname", Telephone = "12345567890", Email = "customer@email.com"},
                        new Customer(){ CustomerID = 09, Code = "CST-00A-009", Name = "Name", Surname = "Surname", Telephone = "12345567890", Email = "customer@email.com"},
                        new Customer(){ CustomerID = 10, Code = "CST-00A-010", Name = "Name", Surname = "Surname", Telephone = "12345567890", Email = "customer@email.com"}
                    };
                    // Colors to be used as row backgrounds
                    this.Colours = new List<SolidColorBrush> 
                    {
                        new SolidColorBrush(Colors.Red),
                        new SolidColorBrush(Colors.Orange),
                        new SolidColorBrush(Colors.Yellow),
                        new SolidColorBrush(Colors.Green),
                        new SolidColorBrush(Colors.Blue),
                        new SolidColorBrush(Colors.Indigo),
                        new SolidColorBrush(Colors.Violet)
                    };          
                }
                // When selected color is changed.
                private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
                {
                    // Set preferred color from combo-box selection
                    ComboBox cb = sender as ComboBox;
                    this.SelectedColor = cb.SelectedItem as SolidColorBrush;
                }
                // When a button is clicked
                private void Button_Click(object sender, RoutedEventArgs e)
                {
                    // Get the clicked button
                    var btn = sender as Button;
                    // use its tag property as a row index
                    int rowIndex = Convert.ToInt32(btn.Tag);
                    // Change the selected row background to the preferred color.
                    this.ChangeRowBackground(rowIndex);
                }
                // Change the selected row background to the preferred color.
                private void ChangeRowBackground(int selectedIndex)
                {
                    // List of items from the datagrid
                    var itemsSource = dgCustomers.ItemsSource as IList;
                    // if such items exist
                    if (itemsSource != null)
                    {
                        // Get each item as a datagrid row based on a selected index.
                        var row = dgCustomers.ItemContainerGenerator.ContainerFromItem(itemsSource[selectedIndex]) as DataGridRow;
                        // if the selected Datagrid Row exists
                        if (row != null)
                        {
                            // change the row background to the preferred color.
                            row.Background = SelectedColor;
                        }
                    }
                }
                // Public Properties
                public IList<Customer> Customers { get; set; }
                public IList<SolidColorBrush> Colours { get; set; }
                public SolidColorBrush SelectedColor { get; set; }
            }
            //Customer Class
            public class Customer 
            {
                // Properties
                public int CustomerID { get; set; }
                public string Code { get; set; }
                public string Name { get; set; }
                public string Surname { get; set; }
                public string Telephone { get; set; }
                public string Email { get; set; }
            }
        }
