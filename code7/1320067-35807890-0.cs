    private void YourRadGridView_AddingNewDataItem(object sender, 
        Telerik.Windows.Controls.GridView.GridViewAddingNewEventArgs e)
    {
        YourObjectModel newItem = new YourObjectModel();
        newItem.Date = DateTime.Now;
        e.NewObject = newItem;
    }
