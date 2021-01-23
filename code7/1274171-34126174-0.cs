    ListViewItem item= new ListViewItem("Test");//Define item here;
    if(!CallTabLv.Items.Contains(theItem))
     {
        CallTabLv.Items.Insert(0,item);
     }
    else
     {
       n = CallTabLv.Items.IndexOf(item);
       CallTabLv.Items.RemoveAt(n);
       CallTabLv.Items.Insert(0, item); 
     }
