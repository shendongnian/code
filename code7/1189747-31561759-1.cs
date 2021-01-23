    private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e){
        //Get the selected combobox item
        ComboBoxItem selectedItem = (String)((ComboBox)sender).SelectedItem;
        //Get the string out of the combobox item
        String name = selectedItem.Content;
        //Get the packageId from the allpackages list
        Int64 packageId = (allPackages.Where(p => p.package.Name.equals(name)).FirstOrDefault()).Id;
        //Put the number in the textbox
        PkgIdBlk.Text = packageId.ToString();
    }
