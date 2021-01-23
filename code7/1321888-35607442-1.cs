    private void listView1_DoubleClick(object sender, EventArgs e)
    {
        // You don't need to check:  if (listView1.SelectedItems.Count > 0)
        foreach (ListViewItem item in listView1.SelectedItems)
        {
            if (!listView2.Items.Contains(item as ListViewItem))
            {
                // listView2 dont have this string. We can add it
                listView2.Items.Add(((ListViewItem)item.Clone());
            }
            else
            {
                //listView2 contains this tring
            }
        }
    }
