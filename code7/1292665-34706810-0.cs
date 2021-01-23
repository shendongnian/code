    public MainPage()
        {
            this.InitializeComponent();
            Grid myGrid = new Grid();
            myGrid.Width = 1000;
            myGrid.Height = 1000;
            myGrid.Visibility = Visibility.Visible;
            for (int i = 0; i < 10; i++)
            {
                RowDefinition rd = new RowDefinition();
                //rd.Height = new GridLength(10);
                ColumnDefinition cd = new ColumnDefinition();
                //cd.Width = new GridLength(10);
                myGrid.RowDefinitions.Add(rd);
                myGrid.ColumnDefinitions.Add(cd);
                TextBlock tb = new TextBlock();
                tb.Text = "Hello";
                Grid.SetRow(tb, i);
                Grid.SetColumn(tb, i);
                myGrid.Children.Add(tb);
            }
            this.fatherGrid.Children.Add(myGrid);
            
        }
