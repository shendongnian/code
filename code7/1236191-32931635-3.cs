    using System;
    using System.Collections.Generic;
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
    
    namespace WpfDataControls
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
        }
    
        public class SalesModelDesignTimeData : SalesModel
        {
            public SalesModelDesignTimeData()
            {
                Items.Add(new SaleItem { Sku = "001", Title = "Pepsi", CostPrice = 10.0, Quantity = 1 });
                Items.Add(new SaleItem { Sku = "002", Title = "Coca Cola", CostPrice = 10.0, Quantity = 1 });
                Items.Add(new SaleItem { Sku = "003", Title = "Colgate Tooth Paste", CostPrice = 8.0, Quantity = 1 });
                Items.Add(new SaleItem { Sku = "004", Title = "Lipton Yello Label", CostPrice = 12.5, Quantity = 1 });
                Items.Add(new SaleItem { Sku = "005", Title = "Sugar", CostPrice = 5.0, Quantity = 1 });
            }
        }
    
        public class SalesModel
        {
            public List<SaleItem> Items { get; set; }
    
            public SalesModel()
            {
                Items = new List<SaleItem>();
            }
        }
    
        public class SaleItem
        {
            public string Sku { get; set; }
            public string Title { get; set; }
            public double CostPrice { get; set; }
            public int Quantity { get; set; }
        }
    
    }
