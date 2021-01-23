        private void TextBlock_GotFocus(object sender, RoutedEventArgs e)
        {
            createNewControl();
        }
        private void createNewControl()
        {
            Grid myOtherGrid = new Grid();
            RowDefinition newRow1 = new RowDefinition();
            newRow1.Height = new GridLength(100.0);
            RowDefinition newRow2 = new RowDefinition();
            newRow2.Height = new GridLength(100.0);
            
            ColumnDefinition newColumn1 = new ColumnDefinition();
            newColumn1.Width = new GridLength(50.0);
            ColumnDefinition newColumn2 = new ColumnDefinition();
            newColumn2.Width = new GridLength(50.0);
            myOtherGrid.RowDefinitions.Add(newRow1);
            myOtherGrid.RowDefinitions.Add(newRow2);
            myOtherGrid.ColumnDefinitions.Add(newColumn1);
            myOtherGrid.ColumnDefinitions.Add(newColumn2);
            TextBox myOtherTextBlock1 = new TextBox();
            myOtherTextBlock1.Text = "new block 1";
            TextBox myOtherTextBlock2 = new TextBox();
            myOtherTextBlock2.Text = "new block 1";
            myOtherGrid.Children.Add(myOtherTextBlock1);
            Grid.SetRow(myOtherTextBlock1, 0);
            Grid.SetColumn(myOtherTextBlock1, 0);
            myOtherGrid.Children.Add(myOtherTextBlock2);
            Grid.SetRow(myOtherTextBlock2, 1);
            Grid.SetColumn(myOtherTextBlock2, 1);
            myGrid.Children.Remove(TextBlock);
            myGrid.Children.Add(myOtherGrid);
        }
