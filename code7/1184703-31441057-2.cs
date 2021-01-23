	public override UITableViewCell GetCell (UITableView tableView, Foundation.NSIndexPath indexPath)
	{
		var cell = tableView.DequeueReusableCell ("CellIdentifier")  as CTextInput ?? new CTextInput ();
	
		var labelText = DataSource.Keys.ElementAt (indexPath.Row);
		var textFieldText = DataSource.Values.ElementAt (indexPath.Row);
	
		cell.SetupCell (labelText, textFieldText, OnTextFieldTextChange);
	
		return cell;
	}
	public void OnTextFieldTextChange (string key, string value)
	{
		if (DataSource.ContainsKey (key)) {
			DataSource [key] = value;
		}
	}
