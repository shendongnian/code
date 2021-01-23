	var recordList = BuildRecords();
	
	var header1 = listView1.Columns.Add("Title", -2, HorizontalAlignment.Left);
	var header7 = listView1.Columns.Add("firstname", -2, HorizontalAlignment.Left);
	var header6 = listView1.Columns.Add("lastname", -2, HorizontalAlignment.Left);
	var header5 = listView1.Columns.Add("pages", -2, HorizontalAlignment.Left);
	var header4 = listView1.Columns.Add("person", -2, HorizontalAlignment.Left);
	var header3 = listView1.Columns.Add("tag", -2, HorizontalAlignment.Left);
	var header2 = listView1.Columns.Add("booknumber", -2, HorizontalAlignment.Left);
	var header8 = listView1.Columns.Add("date", -2, HorizontalAlignment.Left);
	foreach (var record in recordList)
	{
		var lvi = new ListViewrecord(new[] {
			record.Title,
			record.FirstName,
			record.LastName,
			record.Pages[0].ToString(),
			record.person,
			record.Tag,
			record.BookNumber.ToString(),
			record.Date});
		listView1.Items.Add(lvi);
		for (int i = 1; i < record.Pages.Count-1; i++)
		{
			var lvi2 = new ListViewItem(new[] {
			string.Empty,
			string.Empty,
			string.Empty,
			record.Pages[i].ToString(),
			string.Empty,
			string.Empty,
			string.Empty,
     		string.Empty});
			listView1.Items.Add(lvi2);
		}
	}
