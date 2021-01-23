    private void myList_ContainerContentChanging(ListViewBase sender, ContainerContentChangingEventArgs args)
    {
        var listViewItem = args.ItemContainer;
    
        if (listViewItem != null)
        {
            var model = (MyObj)args.Item;
    
            if (model.Disabled)
            {
                listViewItem.IsHitTestVisible = false;
    
                // OR
                //listViewItem.IsEnabled = false;
            }
        }
    }
