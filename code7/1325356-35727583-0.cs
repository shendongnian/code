    public MainWindow()
        {
            InitializeComponent();
            listViewtst.Items.Add("test");
            listViewtst.Items.Add("test2");
            Button btn = new Button();
            btn.Content = "+";
            btn.Click += Btn_Click;
            listViewtst.Items.Add(btn);
        }
        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            listViewtst.Items.Insert(listViewtst.Items.Count - 1, "added by the btn");
            
        }
