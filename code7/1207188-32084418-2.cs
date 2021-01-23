    private void media1_MediaEnded(object sender, RoutedEventArgs e)
    {
        //If a track finishes, check if there are more tracks and 
        //increment to the next one if so.
        if (listbox4.Items.Count > listbox4.SelectedIndex + 1)
        {
            listbox4.SelectedIndex++;
        }
    }
