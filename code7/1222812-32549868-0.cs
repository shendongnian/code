    private void Awesome_Button_Click(object sender, RoutedEventArgs e)
    {
         var item = (sender as Button).DataContext;
         int index = AwesomeListView.Items.IndexOf(item);
         AwesomeListView.SelectedItem = AwesomeListView.Items[index];
    }
