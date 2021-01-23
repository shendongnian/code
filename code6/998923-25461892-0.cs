    public override UITableViewCell GetCell (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath){
        var cell = tableView.DequeueReusableCell (TableCell.Key) as TableCell;
        if (cell == null) {
            cell = new TableCell ();
        }
        cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
        cell.BackgroundColor = (indexPath.Row % 2 == 0) ? UIColor.White : UIColor.LightGray;
    }
