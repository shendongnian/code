    foreach ( GenericObject obj in _genericObjectsCollection )
    {
       ListBoxItem itm = new ListBoxItem();
       itm.Content = obj.itemsTxt;
       itm.Tag = obj;
       listbox1.Items.Add(itm);
    }
