    // set view mode to see columns
    listView1.View = View.Details;
    // 100 is just a length of column. HorizontalAlignment.Left starts from left side    
    listView1.Columns.Add("Name", 100, HorizontalAlignment.Left);
    listView1.Columns.Add("Number", 100, HorizontalAlignment.Left);
    listView1.Columns.Add("Date", 100, HorizontalAlignment.Left);
