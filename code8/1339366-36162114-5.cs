    private void listView_Tapped(object sender, TappedRoutedEventArgs e)
    {
        var obj = (CarItemView) listView.SelectedItem; // convert item to our new class
        Frame.Navigate(typeof(CarShareDetailedPage), obj.Id.ToString()); // send ID as string
    }
