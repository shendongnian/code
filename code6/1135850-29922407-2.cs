    public class CustomTableDataSource : UITableViewSource
    {
    
		private NSString MyCellId { get; set; }
		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = (CustomTableViewCell)tableView.DequeueReusableCell (MyCellId, indexPath);
			cell.load(sampleData[indexPath.row]);
			return cell;
		}
    }
