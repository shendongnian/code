    public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
    {
        var cell = tableView.DequeueReusableCell (CustomCell.Key) as CustomCell ?? new CustomCell ();
        cell.SetupCell (indexPath.Row, _fruits [indexPath.Row], _likeButtonHandler);
        return cell;
    }
