    //iterate rows
    foreach(MyModel model in myDataGrid.Items)
    {
        var selecteditem = model.SelectedItem;//here you have selected item
    }
    
    //access directly
    var model = myDataGrid.Items[0] as MyModel;
    if(model!=null)
       var selecteditem = model.SelectedItem;//here you have selected item
