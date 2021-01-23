    // check if current item matches search string
    private bool ItemMatches(ListViewItem item, string text)
    {
        bool matches = false;
        matches |= item.Text.ToLower().Contains(text.ToLower());
        if (matches)
        {
            return true;
        }
        foreach (ListViewItem.ListViewSubItem subitem in item.SubItems)
        {
            matches |= subitem.Text.ToLower().Contains(text.ToLower());
            if (matches)
            {
                return true;
            }
        }
        return false;
    }
    private void txtJobSearch_TextChanged(object sender, EventArgs e)
    {
        // prevent flickering
        listJobs.BeginUpdate();
        // restore all items in case user deletes some characters in the textbox
        ReinitList();
        string search = txtJobSearch.Text;
        // Search items in our Jobs ListView, remove those that do not match search
        if (search != String.Empty)
        {
            for (int i = listJobs.Items.Count - 1; i >= 0; i--)
            {
                ListViewItem currentItem = listJobs.Items[i];
                if (ItemMatches(currentItem, search))
                {
                    // highlight, or move highlighting to ItemMatches
                }
                else
                {
                    listJobs.Items.RemoveAt(i);
                }
            }
        }
        listJobs.EndUpdate();
    }
    private void ReinitList()
    {
        listJobs.Items.Clear();
        for (int i = 0; i < 50; i++)
        {
            ListViewItem item = new ListViewItem(i.ToString());
            item.SubItems.Add("sub " + i.ToString());
            item.SubItems.Add("sub a" + i.ToString());
            item.SubItems.Add("sub b" + i.ToString());
            listJobs.Items.Add(item);
        }
    }
    private void Form1_Load(object sender, EventArgs e)
    {
        ReinitList();
    }
