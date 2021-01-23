    public class CustomTableSource : UITableSource
    {
        IEnumerable datasource;
        const string cellIdentifier = "YourCustomCell";  
        public CustomTableSource(IEnumerable datasource)
        {
            this.datasource = datasource;
        }  
        public override nint RowsInSection (UITableView tableview, nint section)
        {
            return datasource.Count();
        }   
        
        public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell (cellIdentifier) as YourCustomCell;
            if (cell == null)
                cell = new YourCustomCell(cellIdentifier);
            // populate cell here
            // for if your cell has UpdateData method 
            cell.UpdateData(datasource[indexPath.Row]);
      
            return cell;
        }
    }
