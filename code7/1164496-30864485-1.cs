    private void Button_Click(object sender, RoutedEventArgs e)
    {
        MyData.Add(new object[] { string.Empty, 1, "Robert", DateTime.Now });
        MyData.Add(new object[] { string.Empty, 2, "john", DateTime.Now });
        QuotationDG.ItemsSource = MyData;
    }
