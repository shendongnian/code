    //This one outside
            ObservableCollection<Item> Locals = new ObservableCollection<Item>();
        //in method or constractor
        //foreach
        Item listItem = new Item();
        listItem.Thumbnail = new Uri("ms-appx:///images/coueur_rouge.png", UriKind.Absolute);
        listItem.ButtonColor = new SolidColorBrush(Color.FromArgb(255, 251, 187, 9));
        Locals.Add(listItem);
        //end foreach
        // then do 
        listme.ItemsSource = Locals;
