        private void cbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (isLoaded)
               people.AddFilterAndOrder("Person Category," + ((ViewModel.SystemConfiguration.SystemData.WorkCategory)cbCategory.SelectedItem).PluralTitle, loadModel: true);
        } 
    
