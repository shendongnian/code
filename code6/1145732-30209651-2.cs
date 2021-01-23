    private void menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
    {
        ListView.SelectedListViewItemCollection selectedItems = 
    	ListView1.SelectedItems;
        if (e.ClickedItem.Text == "Copy")
        {
             String text = "";
             foreach ( ListViewItem item in selectedItems )
             {
                  text += item.SubItems[1].Text;
             }
             Clipboard.SetText(text);
        }
    }
