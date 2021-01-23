    private void SetSelectedIndex(ListView list, int index)
    {
        //Deselect other selected items
        list.SelectedItems.Cast<ListViewItem>().ToList()
            .ForEach(item =>
            {
                item.Selected = false;
            });
        //Set selected index if greater than -1
        if (index > -1 && index < list.Items.Count)
            list.Items[index].Selected = true;
    }
