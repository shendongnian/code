    public override UITableViewCell GetCell (UITableView tableView, Foundation.NSIndexPath indexPath)
    {
        var cell = tableView.DequeueReusableCell (CellIndentifer) as DashboardTableCell;
                      
        if (cell == null) {
             // Notice that we are creating an instance of DashboardTableCell
             // instead of UITableViewCell
             cell = new DashboardTableCell (UITableViewCellStyle.Default, CellIndentifer);
        }
        // cell is definitely not null now. You can update and return
        cell.SetupCell (dataLoaded, indexPath);
        return cell;
    }
