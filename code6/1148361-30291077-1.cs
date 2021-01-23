        LinkedList<int> checkedItemQueue = new LinkedList<int>();
        var clb = (CheckedListBox)sender;
        if (e.CurrentValue != CheckState.Checked && e.NewValue == CheckState.Checked)
        {
            checkedItemQueue.AddFirst(e.Index);
            while (checkedItemQueue.Count > 3)
            {
                clb.SetItemChecked(checkedItemQueue.Last.Value, false);
            }
        }
        else if (e.CurrentValue == CheckState.Checked && e.NewValue != CheckState.Checked)
        {
            var node = checkedItemQueue.Find(e.Index);
            if (node != null)
            {
                checkedItemQueue.Remove(node);
            }
        }
