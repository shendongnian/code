    private void onClick(object sender, EventArgs e)
    {
            mylist.Add(new myStruct(){objCB = sender});
    }
    private void btnSave_Click(object sender, RoutedEventArgs e)
    {
            myStruct lastItem = mylist.Last();
            lastItem.ViewType = (rbLine.IsChecked == true) ? "SingleLine" : "Area";
    }
