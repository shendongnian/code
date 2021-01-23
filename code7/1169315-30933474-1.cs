    TextBox tb2 = new TextBox();
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            TextBox tb = new TextBox();
            tb.Text = "some text";
            tb.Width = 200;
           
            tb2.Text = "some text";
            tb2.Width = 200;
            wp.Children.Add(tb); 
            wp.Children.Add(tb2);
        }
