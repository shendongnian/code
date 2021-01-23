    private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listbox1.SelectedItem != null && listbox2.SelectedItems != null)
                ubutton.IsEnabled = true;
            else
                ubutton.IsEnabled = false;
        } 
