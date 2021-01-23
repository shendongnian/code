    private void initiateGrid()
    {
        int numberOfColumn = 10;
            for (int i = 0; i < numberOfColumn; i++)
            {
                ColumnDefinition c1 = new ColumnDefinition();
                c1.Width = new GridLength(1, GridUnitType.Star);
                Test.ColumnDefinitions.Add(c1);
           }
        for (int j = 0; j < (numberOfColumn / 5) + 1; j++)
        {
            RowDefinition r1 = new RowDefinition();
            Test.RowDefinitions.Add(r1);
            for (int i = 0; i < numberOfColumn; i++)
            {
                TextBlock tb = new TextBlock();
                tb.FontSize = 20;
                tb.VerticalAlignment = VerticalAlignment.Top;
                tb.HorizontalAlignment = HorizontalAlignment.Stretch;
                tb.Text = string.Format("Text row {0}, column {1}", j, i);
                Test.Children.Add(tb);
                Grid.SetColumn(tb, i);
                Grid.SetRow(tb, j);
            }
        }
    }
