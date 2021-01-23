    var item1 = new ListViewItem(new[] {"Car", "Boat", "AirPlane"});
    var item2 = new ListViewItem(new[] {"Sheila", "Catherine", "Franz"});
    listViewFilterDescription.Items.Add(item1);
    listViewFilterDescription.Items.Add(item2);
    OR 
        ListViewItem[] item = {item1,item2}; 
        for(int i=0;i<2;i++){ ListViewItem myItem = item[i];
        listViewFilterDescription.Items.AddRange(new ListViewItem[] { myItem}); }    
