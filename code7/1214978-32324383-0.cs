    public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
    {
        var cell = tableView.DequeueReusableCell (cellIdentifier) as YourCustomCell;
        if (cell == null)
            cell = new YourCustomCell(cellIdentifier);
        // populate cell here
        return cell;
    }
