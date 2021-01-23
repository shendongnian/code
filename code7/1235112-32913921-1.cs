    using System;
    using System.Collections.ObjectModel;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Diagnostics;
    
    namespace WpfDataControls.DataGrid
    {
        /// <summary>
        /// Interaction logic for Window1.xaml
        /// </summary>
        public partial class Window1 : Window
        {      
            public Window1()
            {
                InitializeComponent();
    
                dgrdInvoice.AddingNewItem += dgrdInvoice_AddingNewItem;
            }       
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                ViewModel vm = new ViewModel();
                dgrdInvoice.ItemsSource = vm.InvoiceCollection;
            }
    
            #region Grid events
                void dgrdInvoice_LoadingRow(object sender, DataGridRowEventArgs e)
                {
                   e.Row.Loaded += dgrdInvoice_Row_Loaded;                
                }
    
                void dgrdInvoice_Row_Loaded(object sender, RoutedEventArgs e)
                {
                    DataGridRow newRow = ((DataGridRow)sender);
    
                    if (newRow.GetIndex() == dgrdInvoice.Items.Count - 1)
                    {
                        newRow.Background = new SolidColorBrush(Colors.BlanchedAlmond);
                        DependencyObject reference = newRow;
    
                        while (true)
                        {
                            reference = VisualTreeHelper.GetChild(reference, 0);
                            if (reference is TextBlock)
                            {
                                TextBlock f = (TextBlock)reference;
                                f.Text = Convert.ToInt32(tbSupplierInvoiceNumber.Text).ToString();
                                break;
                            }
                        }
                    }
                }
    
                void dgrdInvoice_AddingNewItem(object sender, AddingNewItemEventArgs e)
                {
                    DataGridRow newRow = (DataGridRow)dgrdInvoice.ItemContainerGenerator.ContainerFromIndex(dgrdInvoice.Items.Count - 1);
                    DependencyObject reference = newRow;
                    int invoiceNumber;
                    while (true)
                    {
                        reference = VisualTreeHelper.GetChild(reference, 0);
                        if (reference is TextBlock)
                        {
                            invoiceNumber = Convert.ToInt32(tbSupplierInvoiceNumber.Text);
                            TextBlock f = (TextBlock)reference;
                            f.Text = invoiceNumber.ToString();
                            break;
                        }
                    }
    
                    e.NewItem = new Invoice() { suppInvNumber = invoiceNumber };
                }       
            #endregion
            
        }
    
        public class ViewModel
        {
            ObservableCollection<Invoice> _invoiceCollection;
            public ObservableCollection<Invoice> InvoiceCollection { get { return _invoiceCollection; } }
    
            public ViewModel()
            {
                _invoiceCollection = new ObservableCollection<Invoice>();
    
                _invoiceCollection.Add(new Invoice() { suppInvNumber = 1, quantity=120, unitPrice=23, totalPrice=56 });
                _invoiceCollection.Add(new Invoice() { suppInvNumber = 3, quantity = 122, unitPrice = 13, totalPrice = 23 });
                _invoiceCollection.Add(new Invoice() { suppInvNumber = 4, quantity = 234, unitPrice = 10, totalPrice = 43 });
                _invoiceCollection.Add(new Invoice() { suppInvNumber = 6, quantity = 512, unitPrice = 35, totalPrice = 67 });
                _invoiceCollection.Add(new Invoice() { suppInvNumber = 7, quantity = 612, unitPrice = 3, totalPrice = 120 });
            }
        }
    
        public class Invoice
        {
            public int suppInvNumber { get; set; }
            public int quantity { get; set; }
            public int unitPrice { get; set; }
            public int totalPrice { get; set; }
        }
    }
