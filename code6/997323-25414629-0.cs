    private void ListViewItem_MouseDoubleClick(object sender, RoutedEventArgs e)
    {
         SingleContact contactIndex = new SingleContact((User)this.lbUsers.SelectedItem);
         //if SingleContact is the window
         contactIndex.Show();
    }
