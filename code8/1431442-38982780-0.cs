            public MainWindow()
            {
                InitializeComponent();
                SetupGrid(143);
            }
    
            private void SetupGrid(double width)
            {
                LayoutRoot.ShowGridLines = true;
                int numColumns = Convert.ToInt32(width / 10);
                double remainder = width % 10;
                //create whole columns
                for (int i = 0; i < numColumns; i++)
                {
                    ColumnDefinition col = new ColumnDefinition();
                    col.Width = new GridLength(10, GridUnitType.Star);
                    LayoutRoot.ColumnDefinitions.Add(col);
                    //adding a textblock just so show the placement
                    TextBlock t = new TextBlock();
                    t.HorizontalAlignment = HorizontalAlignment.Center;
                    t.Text = i.ToString();
                    LayoutRoot.Children.Add(t);
                    Grid.SetColumn(t, i);
                }
                //create remainder
                ColumnDefinition colr = new ColumnDefinition();
                colr.Width = new GridLength(remainder, GridUnitType.Star);
                LayoutRoot.ColumnDefinitions.Add(colr);
                //adding a textblock just so show the placement
                TextBlock t2 = new TextBlock();
                t2.HorizontalAlignment = HorizontalAlignment.Center;
                t2.Text = remainder.ToString();
                LayoutRoot.Children.Add(t2);
                Grid.SetColumn(t2, numColumns + 1);
            }
