    private void MyListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        //suppose MyClass is the class you used in binding
        var selected = MyListBox.SelectedItem as MyClass;
        //Date is the property you bind to txtDate
        string date = selected.Date.ToString();
    }
