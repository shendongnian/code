    private void BtnDelete_OnClick(object sender, RoutedEventArgs e)
    {
        var s = (((sender as Button).DataContext) as YourModel).Property;
        //Write Delete code based on "s" value
    }
