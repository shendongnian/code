	var recordList = BuildRecords();
	
	foreach (var item in recordList)
	{
		// To distinguish between 'pages' and other properties
		var gap = "    ";
		listBox1.Items.Add(item.Title);
		listBox1.Items.Add(item.FirstName);
		listBox1.Items.Add(item.LastName);
		foreach (var page in item.Pages)
		{
			listBox1.Items.Add(gap + page);
		}
		listBox1.Items.Add(item.person);
		listBox1.Items.Add(item.Tag);
		listBox1.Items.Add(item.BookNumber);
		listBox1.Items.Add(item.Date);
	}
	
