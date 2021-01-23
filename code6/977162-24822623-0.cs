    public partial class Page2 : PhoneApplicationPage
    {
        public Product GetProduct { get; set; }
        public Page2()
        {
            InitializeComponent();
        }
        private void Add_Click_1(object sender, RoutedEventArgs e)
        {
            Product p2 = stkProduct.DataContext as  Product;
          //  p2.Name = txtName1.Text;
            if (string.IsNullOrEmpty(p2.ID))
            {
                p2.ID = DateTime.Now.ToString("yyyyMMddhhmmsstt");
                App.lstp.Add(p2);
            }
            else
            {
                int index = App.lstp.IndexOf(p2);
                App.lstp.Remove(GetProduct);
                App.lstp.Insert(index, p2);
            }
            NavigationService.Navigate(new Uri(@"/MainPage.xaml", UriKind.Relative));
        }
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            if (GetProduct == null)
            {
                GetProduct = new Product();
            }
            stkProduct.DataContext = GetProduct;
        }
    }
