    lView1.View = View.Details;
    Add your columns
            lView1.Columns.Add("ID");
            lView1.Columns.Add("Name");
    		
    Add the listview items
            lView1.Items.Add(new ListViewItem(new string[]{"1", "name1"}));
            lView1.Items.Add(new ListViewItem(new string[]{"4", "name2"}));
            lView1.Items.Add(new ListViewItem(new string[]{"2", "name3"}));
