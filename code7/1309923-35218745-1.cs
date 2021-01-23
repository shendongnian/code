            Grid objGrid = new Grid();
            objGrid.BackgroundColor = Color.Gray;
            //
            objGrid.RowDefinitions.Add(new RowDefinition
            {
              Height = new GridLength(1, GridUnitType.Star)
            });
            //
            objGrid.ColumnDefinitions.Add(new ColumnDefinition
            {
                Width = new GridLength(75, GridUnitType.Absolute)
            });
            objGrid.ColumnDefinitions.Add(new ColumnDefinition
            {
                Width = new GridLength(1, GridUnitType.Star)
            });
            objGrid.ColumnDefinitions.Add(new ColumnDefinition
            {
                Width = GridLength.Auto
            });
            //
            // Column 1:-
            Image objImage = new Image();
            objImage.BackgroundColor = Color.Green;
            objImage.Source = ImageSource.FromFile("Image1.png");
            objGrid.Children.Add(objImage, 0,0);
            //
            // Column 2:-
            StackLayout objStackLayoutCol2 = new StackLayout();            
            objGrid.Children.Add(objStackLayoutCol2, 1,0);
            Label objLabel1 = new Label()
            {
                Text = "Name"
            };
            Label objLabel2 = new Label()
            {
                Text = "Date"
            };
            objStackLayoutCol2.Children.Add(objLabel1);
            objStackLayoutCol2.Children.Add(objLabel2);
            //
            // Column 3:-
            Switch objSwitch = new Switch();
            objGrid.Children.Add(objSwitch, 2,0);
