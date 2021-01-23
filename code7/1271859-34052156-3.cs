    private void SomeButton_Click(object sender, RoutedEventArgs e)
    {
        foreach(MyDataObject item in listBox.Items)
        {
            if (item.IsChecked)
                Console.WriteLine("Item " + item.Caption + " is checked");
        }
    }
