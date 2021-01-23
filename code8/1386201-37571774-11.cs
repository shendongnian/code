    private void cbItems_TextChanged(object sender, TextChangedEventArgs e)
    {
        string text = ((ComboBox)sender).Text;
       ((YourViewModel)this.DataContext).ItemId= text;
    }
