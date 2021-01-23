    private void listView1_DoubleClick(object sender, EventArgs e)
    {
        // You don't need to check:  if (listView1.SelectedItems.Count > 0)
        foreach (ListViewItem item in listView1.SelectedItems)
        {
            bool isExist = false;
            foreach (ListViewItem item2 in listView2.Items)
            {
                if (item2.Text == item.Text) // Compare Text
                //if (item2.ImageKey == item.ImageKey) // Compare Key. If you don't use key then ignore this line
                {
                    isExist = true;
                    break;
                }
            }
            if (!isExist) listView2.Items.Add((ListViewItem)item.Clone());
        }
    }
