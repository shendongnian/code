	private void Replace(string x)
	{
		if (x == "(null)")
			x = "NULL";
		else
			x = string.Format("'{0}'", x);
	}
    var list = lineArray.ToList();
    list.ForEach(Replace);
    // check list here and make sure that there are no changes
