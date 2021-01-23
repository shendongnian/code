    ListViewGroup lvg = this.listView_History.Groups.Cast<ListViewGroup>()
        .Where(x => x.Header == "MyString").FirstOrDefault();
                                
    if (lvg == null)
    {
        lvg = new ListViewGroup("MyString");
        listView_History.Groups.Add(lvg)
    }
    
    ListViewItem LVI = new ListViewItem();
    LVI.Group = lvg;
