    var myList = new List<string>();
        foreach (ListViewItem Item in listView2.Items)
        {
           for ( int i = 0 ; i < item.Count ; i++ )
           {
                myList.Add(Item[i].ToString());
           }   
            
        }
