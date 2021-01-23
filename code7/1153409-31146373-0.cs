    enum GridItemColor
    {
        NONE,
        BLUE,
        RED
    };
    
    //Some event to populate a list
    ...
    myGrid.Items.Clear();
    GridItemColor lastColor = GridItemColor.NONE;
    foreach (MyModel item in myList)
    {
        if (lastColor == GridItemColor.NONE || lastColor == GridItemColor.BLUE)
        {
            myGrid.Items.Add(FormatGridViewItem(item, GridItemColor.RED));
            lastColor = GridItemColor.RED;
        }
        else if (lastColor == GridItemColor.RED)
        {
            myGrid.Items.Add(FormatGridViewItem(item, GridItemColor.BLUE));
            lastColor = GridItemColor.BLUE;
         }
    }
    ...
    private Grid FormatGridViewItem(MyModel currentItem, GridItemColor itemColor)
        {
            Grid gridItem = new Grid();
            #region Grid Item Row Definition and GridItem Setup
            RowDefinition itemRowDef = new RowDefinition();
            RowDefinition minorButtonRowDef = new RowDefinition();
            itemRowDef.Height = new GridLength(72);
            minorButtonRowDef.Height = new GridLength(49);
            gridItem.RowDefinitions.Add(classPlanRowDef);
            gridItem.RowDefinitions.Add(minorButtonRowDef);
            gridItem.MaxWidth = 196;
            gridItem.Width = 196;
            gridItem.Margin = new Thickness(0, 0, 24, 24);
            #endregion
            #region Button Item
            Button btnItem = new Button();
            btnItem.BorderThickness = new Thickness(0);
            btnItem.Margin = new Thickness(-3, 0, 0, 0);
            btnItem.Opacity = 100;
            btnItem.MaxWidth = 203;
            btnItem.MinWidth = 203;
            btnItem.Height = 78;
            btnItem.DataContext = currentItem;
            if (itemColor == GridItemColor.RED)
                btnItem.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(0xFF, 255, 107, 51));
            else
                btnItem.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(0xFF, 23, 229, 192));
            btnItem.Click += btnItem_Click;
            TextBlock txtItem = new TextBlock();
            txtItem.FontSize = 40;
            if (itemColor == GridItemColor.RED)
                txtItem.Foreground = new SolidColorBrush(Windows.UI.Color.FromArgb(0xFF, 91, 31, 8));
            else
                txtItem.Foreground = new SolidColorBrush(Windows.UI.Color.FromArgb(0xFF, 3, 97, 80));
            txtItem.Opacity = 100;
            txtItem.TextAlignment = TextAlignment.Center;
            txtItem.Text = currentItem.Name;
            txtItem.TextTrimming = TextTrimming.CharacterEllipsis;
            btnItem.Content = txtItem;
            gridItem.Children.Add(btnItem);
            Grid.SetRow(btnItem, 0);
            #endregion
            #region Grid Minor Buttons Row
            Grid minorButtonsRow = new Grid();
            minorButtonsRow.Margin = new Thickness(0);
            if (itemColor == GridItemColor.RED)
                minorButtonsRow.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(0xFF, 255, 107, 51));
            else
                minorButtonsRow.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(0xFF, 23, 229, 192));
            ColumnDefinition btnOneColumnDef = new ColumnDefinition();
            ColumnDefinition btnTwoColumnDef = new ColumnDefinition();
            btnOneColumnDef.Width = new GridLength(98);
            btnTwoColumnDef.Width = new GridLength(98);
            minorButtonsRow.ColumnDefinitions.Add(btnOneColumnDef);
            minorButtonsRow.ColumnDefinitions.Add(btnTwoColumnDef);
            // Button One
            Button btnOne = new Button();
            btnOne.BorderBrush = new SolidColorBrush(Windows.UI.Color.FromArgb(0xFF, 255, 255, 255));
            btnOne.BorderThickness = new Thickness(0);
            btnOne.MinWidth = 97;
            btnOne.MaxWidth = 97;
            btnOne.MinHeight = 48;
            btnOne.MaxHeight = 48;
            btnOne.Margin = new Thickness(0, 0, 1, 0);
            btnOne.DataContext = currentItem;
            btnOne.Click += btnOne_Click;
            ImageBrush imgOne = new ImageBrush();
            BitmapImage bitImg;
            if (itemColor == GridItemColor.RED)
            {
                bitImg = new BitmapImage(new Uri("ms-appx:/Assets/Icons/btOneRED.png", UriKind.RelativeOrAbsolute));
                btnOne.Style = (Style)this.Resources["btnOneRedStyle"];
            }
            else
            {
                bitImg = new BitmapImage(new Uri("ms-appx:/Assets/Icons/btOneBLUE.png", UriKind.RelativeOrAbsolute));
                btnOne.Style = (Style)this.Resources["btnOneBlueStyle"];
            }
            imgOne.ImageSource = bitImg;
            imgOne.Stretch = Stretch.UniformToFill;
            btnOne.Background = imgOne;
            minorButtonsRow.Children.Add(btnOne);
            Grid.SetRow(btnOne, 0);
            Grid.SetColumn(btnOne, 0);
            // END Button One
            // Button Two
            Button btnTwo = new Button();
            btnTwo.BorderBrush = new SolidColorBrush(Windows.UI.Color.FromArgb(0xFF, 255, 255, 255));
            btnTwo.BorderThickness = new Thickness(0);
            btnTwo.MinWidth = 97;
            btnTwo.MaxWidth = 97;
            btnTwo.MinHeight = 48;
            btnTwo.MaxHeight = 48;
            btnTwo.Margin = new Thickness(1, 0, 0, 0);
            btnTwo.DataContext = currentItem;
            btnTwo.Click += btnTwo_Click;
            ImageBrush imgTwo = new ImageBrush();
            BitmapImage bitImgTwo;
            if (itemColor == GridItemColor.RED)
            {
                bitImgTwo = new BitmapImage(new Uri("ms-appx:/Assets/Icons/btTwoRED.png", UriKind.RelativeOrAbsolute));
                btnTwo.Style = (Style)this.Resources["btnTwoRedStyle"];
            }
            else
            {
                bitImgTwo = new BitmapImage(new Uri("ms-appx:/Assets/Icons/bt_AgendaVerde.png", UriKind.RelativeOrAbsolute));
                btnTwo.Style = (Style)this.Resources["btnTwoBlueStyle"];
            }
            imgTwo.ImageSource = bitImgTwo;
            imgTwo.Stretch = Stretch.UniformToFill;
            btnTwo.Background = imgTwo;
            minorButtonsRow.Children.Add(btnTwo);
            Grid.SetRow(btnTwo, 0);
            Grid.SetColumn(btnTwo, 1);
            gridItem.Children.Add(minorButtonsRow);
            Grid.SetRow(minorButtonsRow, 1);
            Grid.SetColumn(minorButtonsRow, 0);
            // END Button Two
            #endregion 
            return gridItem;
        }
