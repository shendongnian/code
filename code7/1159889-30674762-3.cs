    async void  OnValueChanged (object sender, TextChangedEventArgs e) {
        var t = e.NewTextValue;
        // perform search on min 3 keypress
        if (t.Length>3) {
           App.TodoManager.TodoViewModel.TodoItems = App.TodoManager.GetFilteredList(searchFor.Text);
            listViewTasks.ItemsSource = App.TodoManager.TodoViewModel.TodoItems; 
         }
    }
