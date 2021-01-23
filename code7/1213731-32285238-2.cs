    // ...
    ItemTemplate = new DataTemplate(() =>
    {
        // Create views with bindings for displaying each property.
        Label nameLabel = new Label();
        nameLabel.SetBinding(Label.TextProperty, "Name");
    
        Label birthdayLabel = new Label();
        birthdayLabel.SetBinding(Label.TextProperty,
            new Binding("Birthday", BindingMode.OneWay, 
                        null, null, "Born {0:d}"));
    
        BoxView boxView = new BoxView();
        boxView.SetBinding(BoxView.ColorProperty, "FavoriteColor");
    
        // Return an assembled ViewCell.  <<--------------------------------------
        return new ViewCell
        {
            View = new StackLayout
            {
                Padding = new Thickness(0, 5),
                Orientation = StackOrientation.Horizontal,
                Children = 
                {
                    boxView,
                    new StackLayout
                    {
                        VerticalOptions = LayoutOptions.Center,
                        Spacing = 0,
                        Children = 
                        {
                            nameLabel,
                            birthdayLabel
                        }
                    }
                }
            }
        };
    })
    // ...
