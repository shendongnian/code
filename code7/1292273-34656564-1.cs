    private void HistoryItem_Selected(object sender, RoutedEventArgs e)
    {
       // here 'sender' will be the ListItem which you clicked on
       // but since it's an object we need to cast it first
       ListViewItem listItem = (ListViewItem)sender;
       // now all that's left is getting the text and assigning it to the textbox
       innerTextBox.Text = listItem.Content.ToString();
    }
