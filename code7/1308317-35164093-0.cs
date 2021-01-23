    //assuming you have Menu named MainMenu and you want to add Menu Item to it and Sub menu item to the item which you have just added
          MenuItem MainItem = new MenuItem();
          MainItem .Header = "Main Item";
          this.MainMenu.Items.Add(MainItem);
    
          MenuItem SubItem= new MenuItem();
          SubItem.Header = "Sub Item";
          SubItem.Click += new RoutedEventHandler(SubItem_Click);
          MainItem.Items.Add(SubItem);
