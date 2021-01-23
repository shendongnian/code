    private void VegeListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // If selected index is -1 (no selection) do nothing
            if (VegeListBox.SelectedIndex == -1)
                return;
    //Make the selected item in the VegeListBox an instance of a Vegetable
           Vegetable selectedVege = (sender as ListBox).SelectedItem as Vegetable;
            // Navigate to the new page
            if (selectedVege != null)
            {
                //Navigate to the Carrot page sending the ID property of the selectedVege as a parameter query
               NavigationService.Navigate(new Uri(string.Format("/Carrot.xaml?parameter={0}", selectedVege.ID), UriKind.Relative));
            }
            // Reset selected index to -1 (no selection)
            VegeListBox.SelectedIndex = -1;
        }
