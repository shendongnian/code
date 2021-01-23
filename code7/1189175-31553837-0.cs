    olv.ItemChecked += delegate(object sender, ItemCheckedEventArgs e)
    {
        var item = e.Item as OLVListItem;
        if (item != null && e.Item.Checked)
        {
            var objects = ObjectListView.EnumerableToArray(olv.Objects, true);
            objects.Remove(item.RowObject);
            olv.UncheckObjects(objects);
        }
    }
