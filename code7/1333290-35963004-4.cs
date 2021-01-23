    private void Button_Click(object sender, RoutedEventArgs e)
    {
        results.ItemsSource = null;
        results.ItemsSource = new List<SomeType>(); // replace SomeType with the type of ID.
        results.Items.Add(ID);          
    }
