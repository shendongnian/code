    public class TableSource : UITableViewSource
    {
        public static string SelectedRow;
        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            new UIAlertView("Row Selected", TableItems[indexPath.Row], null, "OK").Show();
            SelectedRow = TableItems[indexPath.Row];
        }
    }
