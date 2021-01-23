    private void personelEntityDataGrid_SelectionChanged(object sender, RoutedEventArgs e)
    {
        PersonelEntity pers = (PersonelEntity)personelEntityDataGrid.SelectedItem;
        if(pers != null)
        {
        NameBox.Text = pers.Name; // I get exception here
        AgeBox.Text = pers.Age.ToString();
        PhoneNumberBox.Text = pers.PhoneNumber;
        AddresBox.Text = pers.Address;
        }
    
    }
