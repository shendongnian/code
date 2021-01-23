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
                ApplicationBarIconButton btn = (ApplicationBarIconButton)ApplicationBar.Buttons[0];
                btn.Text = "Add";
                btn.IconUri = new Uri("/Assets/check.png", UriKind.Relative);
            }
            else
            {
                ApplicationBarIconButton btn = (ApplicationBarIconButton)ApplicationBar.Buttons[0];
                btn.Text = "save";
                btn.IconUri = new Uri("/Assets/save.png", UriKind.Relative);
            }
            stkProduct.DataContext = GetProduct;
            
            
        }
        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {
            Product p2 = stkProduct.DataContext as Product;
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
    }
