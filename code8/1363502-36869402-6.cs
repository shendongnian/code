    public void CheckBoxCal_Checked(object sender, EventArgs args)
    {
        var listItem = ((FrameworkElement)sender).DataContext as ListItem;
        //  Do whatever. listItem.IsChecked will be up to date thanks 
        //  to the binding.
    }
   
