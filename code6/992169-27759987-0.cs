        private FrameworkElement CreateGrid(int i)
        {
            double w = 775;
            double l = 1105;
            TextBlock header = CreateHeader("someRndStuffHeader");
            RowDefinition headerRowDefinition = new RowDefinition
            {
                MinHeight = header.ActualHeight,
                MaxHeight = header.ActualHeight,
            };
            TextBlock footer = CreateFooter("someRndStuffFooter");
            RowDefinition footerRowDefinition = new RowDefinition
            {
                MinHeight = footer.ActualHeight,
                MaxHeight = footer.ActualHeight
            };
            double contentHeight = l - header.ActualHeight - footer.ActualHeight;
            RowDefinition contentRowDefinition = new RowDefinition
            {
                MinHeight = contentHeight,
                MaxHeight = contentHeight,
            };
            ColumnDefinition gridColumnDefinition = new ColumnDefinition()
            {
                MaxWidth = w,
                MinWidth = w,
            };
            Grid page = new Grid();
            string name = "printPage" + i.ToString();
            page.Name = name;
            page.RowDefinitions.Add(headerRowDefinition);
            page.RowDefinitions.Add(contentRowDefinition);
            page.RowDefinitions.Add(footerRowDefinition);
            page.ColumnDefinitions.Add(gridColumnDefinition);
          
            **Grid.SetRow(header, 1);
            page.Children.Add(header);
            page.Children.Add(footer);**
            return page;
        }
        private TextBlock CreateFooter(string p)
        {
            return new TextBlock() { Width=300,Height=300,Text=p};
        }
        private TextBlock CreateHeader(string p)
        {
            return new TextBlock() { Width = 300, Height = 300, Text = p };
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            layout.Children.Add(CreateGrid(1));
        }
