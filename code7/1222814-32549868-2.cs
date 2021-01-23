    private void Awesome_Button_Click(object sender, RoutedEventArgs e)
    {
         var item = (sender as Button).DataContext;
         int index = AwesomeListView.Items.IndexOf(item);//find the index of the item that contains the clicked button
         AwesomeListView.SelectedItem = AwesomeListView.Items[index];//set the AwesomeListView's SelectedItem to item that contains the clicked button
    }
