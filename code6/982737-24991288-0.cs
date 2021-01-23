    private void add_Click(object sender, RoutedEventArgs e)
    {
        tableAdapterServices.InsertQuery(txtTobeAdded.Text);
        service.ItemsSource = tableAdapterServices.GetData().DefaultView;;
        service.SelectedIndex = 0;
    }
