    //Just for sample, you should add some checks and raise some events and throw some exceptions.
    public int SelectedIndex
    {
        get
        {
            var selectedIndex = -1;
            if (this.listView1.SelectedItems.Count == 1)
                selectedIndex = this.listView1.SelectedItems[0].Index;
            return selectedIndex;
        }
        set
        {
            this.listView1.SelectedItems.Cast<ListViewItem>()
                .ToList().ForEach(item =>
                {
                    item.Selected = false;
                });
            this.listView1.Items[value].Selected = true;
        }
    }
