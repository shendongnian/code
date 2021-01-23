    for (int i = lstItem2.Items.Count - 1; i >= 0; i--)
    {
        if (!cbxItem.Items.Contains(lstItem2.Items[i]))
        {
            cbxItems.Items.Add(lstItems2.Items[i]);
            lstItems2.Items.RemoveAt(i);
        }
    }
