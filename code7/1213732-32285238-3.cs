    ListView listView = new ListView
    {
        // Source of data items.
        ItemsSource = devices,
        
        ItemTemplate = new DataTemplate(new Func<object>(() =>
        {
            // Create views with bindings for displaying each property.
            Label nameLabel = new Label();
            nameLabel.SetBinding(
                Label.TextProperty, "{Binding Name, Converter={StaticResource strConverter}}"
            );
            
            Label IDLabel = new Label();
            IDLabel.SetBinding(
                Label.TextProperty, "{Binding Path=ID, Converter={StaticResource guidConverter}}"
            );
            
            return new ViewCell
            {
                View = new StackLayout
            };
        }));
    }
