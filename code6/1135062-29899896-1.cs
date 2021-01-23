     public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
        {
            UITableViewCell cell = tableView.DequeueReusableCell (MyCellId) as UITableViewCell;
            if (cell == null) {
    	         cell = new UITableViewCell (UITableViewCellStyle.Value1, MyCellId);
            }
            cell.TextLabel.Text = "TextLabel";
            cell.DetailTextLabel.Text = "DetailTextLabel";
    
            return cell;
        }
