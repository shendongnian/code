    private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (MyListView.SelectedItem.Equals(FristItem))
        {
        }
        else if (MyListView.SelectedItem.Equals(SecondItem))
        {
        }
    }
    
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        mySplitView.IsPaneOpen = !mySplitView.IsPaneOpen;
    }
