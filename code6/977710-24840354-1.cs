    int count = 0;
        public MainPage()
        {
            InitializeComponent();
            List<Items> list1;
            list1 = new List<Items>();
            list1.Add(new Items() { Types = "CheckBox1", IsSelectedRoles = false });
            list1.Add(new Items() { Types = "CheckBox2", IsSelectedRoles = false });
            list1.Add(new Items() { Types = "CheckBox3", IsSelectedRoles = false });
            list1.Add(new Items() { Types = "CheckBox4", IsSelectedRoles = false });
            list1.Add(new Items() { Types = "CheckBox5", IsSelectedRoles = false });
            list1.Add(new Items() { Types = "CheckBox6", IsSelectedRoles = false });
            this.listBox.ItemsSource = list1;
        }
        private void btnAddtoCompare_Click(object sender, RoutedEventArgs e)
        {
            Items _items;
            _items = new Items();
            _items.Cakes = listBox.ItemsSource;
            foreach (Items i in _items.Cakes)
            {
                if (i.IsSelectedRoles)
                    count = count + 1;
            }
            if (count > 2)
            {
                MessageBox.Show("Select only two items");
                count = 0;
            }
            else
            {
                // Navigate to Next page.
            }
            count = 0;
        }
