    else
    {
        foreach (ListViewItem item in source.SelectedItems)
        {
            ListViewItem lvItem = item.Clone() as ListViewItem;
            int index = dictList[item.Text];
            // Insert at appropriate position based on index value
            if (index == 0) // Always first
                target.Items.Insert(0, lvItem);
            else if (index == dictList.Count - 1) // Always last
                target.Items.Add(lvItem);
            else
            {
                // Binary search the current target items
                int lo = 0, hi = target.Items.Count - 1;
                while (lo <= hi)
                {
                    int mid = lo + (hi - lo) / 2;
                    if (index < dictList[target.Items[mid].Text])
                        hi = mid - 1;
                    else
                        lo = mid + 1;
                }
                // Here lo variable contains the insert position
                target.Items.Insert(lo, lvItem);
            }
            source.Items.Remove(item);
        }
    }
