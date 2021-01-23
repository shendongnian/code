    ListViewItemCollection items = lvcust.Items;
    for(int i=0;i<items.Count;i++){
      ListViewItem item = items.Item[i];
      object tag = item.Tag;
      if(tag is string){
        item.Text = ((string)tag).ToUpper();
      }
    }
