        PivotItem selected;
        public MainPage()
        {
            InitializeComponent();
            selected = one;
        }
        private void Pivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selected.Content = null;
            switch(myPivot.SelectedIndex)
            {
                case 0:
                    one.Content = content;
                    selected = one;
                    break;
                case 1:
                    two.Content = content;
                    selected = two;
                    break;
                case 2:
                    three.Content = content;
                    selected = three;
                    break;
            }
        }
