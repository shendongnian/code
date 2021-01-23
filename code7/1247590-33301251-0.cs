    namespace BarcodeImplementationInDG
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            List<Products> lst = new List<Products>();
            public MainWindow()
            {
                InitializeComponent();
                dg.ItemsSource = lst;
            }
        }
        public class Products
        {
            public string Product { get; set; }
            public string Barcode { get; set; }
        }
    }
