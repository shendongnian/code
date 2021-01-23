        var cell = new DataTemplate(typeof(ImageCell));
        cell.SetBinding(ImageCell.ImageSourceProperty, "Afbeelding");
        cell.SetBinding(TextCell.TextProperty, "Naam");
        cell.SetBinding(TextCell.DetailProperty, "Omschrijving");
        var listview = new ListView
        {
            ItemsSource = Graanziekten,
            ItemTemplate = cell
        };
