	var listView = new TreeView ();
	listView.HeadersVisible = false;
	listStore = new ListStore (typeof(string));
	listView.Model = listStore;
	var cellView = new CellRendererText ();
	var column = new TreeViewColumn ("Title", cellView);
	column.AddAttribute (cellView, "text", 0);
	listView.AppendColumn (column);
