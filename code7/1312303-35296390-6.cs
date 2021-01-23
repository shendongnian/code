    private void Button_Tapped(object sender, TappedRoutedEventArgs e)
            {
                Item selectedItem = ((FrameworkElement)sender).DataContext as Item;
                SelectedItem.Thumbnail = null;//whatever you like
                SelectedItem.ButtonColor = null;//whatever you like
            }
