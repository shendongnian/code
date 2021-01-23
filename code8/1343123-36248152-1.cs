    // Loop over the items in the first list....
    for (int i = 0; i < listView1.Items.Count; i++)
    {
        // Get the item at i pos in the first item                     
        string testing = listView1.Items[i].Text;
        // Search it in the second listview
        ListViewItem item = listView2.FindItemWithText(testing);
        // If not found...
        if (item == null)
        { 
            // Add the text to the third listview
            listView3.Items.Add(testing);
        }
        else
        {
            MessageBox.Show("Item exists");
        }
    }
