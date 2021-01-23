    private void myListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.AddedItems.Count > 0) //check that there actually is a selected row
        {
            myLabel.Content = (myListView.SelectedItem as System.Data.DataRowView)["ItemLabel"].ToString()
        }
    }
