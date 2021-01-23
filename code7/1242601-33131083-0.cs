    var allnames =
        listView1.Items.OfType<ListViewItem>()
            .Select(x => new {NickName = x.SubItems[0], FullName = x.SubItems[1]})
            .ToArray();
    // usage
    foreach(var n in allnames)
    {
         string nickname = n.NickName;
         string fullname = n.FullName;
    }
