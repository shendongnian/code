    private void DataGrid_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
    {
        if ((selectedRow as DataGridRow).Item.ToString() != "{NewItemPlaceholder}")
        {
            //Here you can add the code to add new item. I don't know how but you should figure out a way
        }
    }
