    private void List1_DragItemsStarting(object sender, Windows.UI.Xaml.Controls.DragItemsStartingEventArgs e)
    {
        var items = new StringBuilder();
        foreach (MyClass item in e.Items)
        {
            if (items.Length > 0) items.AppendLine();
            items.Append(item.ID);
        }
        e.Data.SetText(items.ToString());
        //As we want our Reference list to say intact, we only allow Copy
        e.Data.RequestedOperation = DataPackageOperation.Copy;
    }
