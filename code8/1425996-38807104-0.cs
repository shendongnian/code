    private void listView1_MouseClick(object sender, MouseEventArgs e)
    {
        // Get the information of an item that is located in a given point (mouse location in this case).
        ListViewHitTestInfo hit = listView1.HitTest(e.Location);
        // hit.Item: Gets the ListViewItem.
        // hit.SubItem: Get the ListViewItem.ListViewSubItem
    
        if (listView1.SelectedItems.Count > 0)
        {
            MessageBox.Show("You clicked " + hit.SubItem.Text);
        }
        else
        {
            MessageBox.Show("Please select an item");
        }
    }
