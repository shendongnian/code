    NSIndexPath previouslySelected = null;
    public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
    {
        if(previouslySelected != null){
            var lastCell = tableView.CellAt(previouslySelected);
            lastCell.Accessory = UITableViewCellAccessory.None;
        }
        previouslySelected = indexPath;
        SelectedRow = TableItems[indexPath.Row];
        var cell = tableView.CellAt(indexPath);
        cell.Accessory = (indexPath.Row >= 0) ? UITableViewCellAccessory.Checkmark : UITableViewCellAccessory.None;
    }
