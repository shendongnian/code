	string aheading = "Defects:";
	string bheading = "Comments:";
	
	int maxlength = 0;
	foreach (var item in chkList.CheckItems)
	{
		if (item.ItemTitle.Length > maxlength)
			maxlength = item.ItemTitle.Length;
	}
	
	int padding = maxlength + 10;  //10 spaces between the longest 'Defects' and its 'Comments'
    string format = "{0,-" + padding + "} {1,-" + padding + "}\r\n"
	string result = String.Format(format, "Defects:", "Comments:");
	foreach (var item in chkList.CheckItems)
	{
		if (item.Defect == true)
		{
			result += String.Format(format, item.ItemTitle, Item.Comment);
		}
	}
