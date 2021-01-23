    private void onClick(object sender, EventArgs e)
    {
            myStruct lastItem = mylist.Last();
            if(myStruct != null && myStruct.AddedStatus == false)
                mylist.Remove(lastItem);
            mylist.Add(new myStruct(){objCB = sender, AddedStatus = false});
    }
    private void btnSave_Click(object sender, RoutedEventArgs e)
    {
            myStruct lastItem = mylist.Last();            
            lastItem.ViewType = (rbLine.IsChecked == true) ? "SingleLine" : "Area";
            lastItem.AddedStatus = true;
    }
