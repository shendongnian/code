    private void listView1_DoubleClick(object sender, EventArgs e)
    {
       if (listView1.SelectedItems.Count > 0)
       {
           foreach (ListViewItem item in listView1.SelectedItems)
           { 
              if(!listView2.Items.Contains(item)) //verify text and value. if don't contain add
                  listView2.Items.Add((ListViewItem)item.Clone());
          }
       }
 
    }
