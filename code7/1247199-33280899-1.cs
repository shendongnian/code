        public Form2(ListBox listy)
        {
            InitializeComponent();
    
             foreach (var item in listy.Items)
             {
                label1.Text += item.ToString();
             }
         }
