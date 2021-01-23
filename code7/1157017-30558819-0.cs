	listView1.Columns.Add("ColumnOne", 150);
	listView1.Columns.Add("ColumnTwo", 150);
	listView1.Columns.Add("ColumnThree", 150);
	listView1.Columns.Add("ColumnFour", 150);
	listView1.Columns.Add("ColumnFive", 150);
	listView1.Columns.Add("Column6", 150);
	foreach (MyClass et in _myData)
	{
		ListViewItem lt = new ListViewItem(et.DataOne.ToString());
	
		lt.SubItems.Add(et.DataTwo.ToString());
		lt.SubItems.Add(et.DataThree.ToString());
		lt.SubItems.Add(et.DataFour.ToLongDateString());
		lt.SubItems.Add(et.DataFive);
		lt.SubItems.Add(et.DataSix);
		
        // I added this to your code
		listView1.Items.Add(lt);
	}
