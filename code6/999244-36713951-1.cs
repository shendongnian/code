    //Table Source
    		public class SampleTableViewSource : UITableViewSource
    		{
    			string CellIdentifier = "sampleTableViewCellID";
    			string CellIdentifier2 = "sampleTableViewCell2ID";
    	
    			public override nint RowsInSection(UITableView tableview, nint section)
    			{
    				return 2;
    			}
    			public override nint NumberOfSections (UITableView tableView)
    			{
    				return 1;
    			}
    			public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
    			{
    				UITableViewCell cell = new UITableViewCell ();
    			
    				//---- if there are no cells to reuse, create a new one
    
    				if (indexPath.Row == 0)
    					{
    					cell = tableView.DequeueReusableCell (CellIdentifier) as SampleTableViewCell;				
    					}
    					else if(indexPath.Row == 1 ) {
    					cell = tableView.DequeueReusableCell (CellIdentifier2) as sampleTableViewCell2;
    					}
    
    				return cell;
    			}
    			public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
    			{
    				tableView.DeselectRow (indexPath, true);
    		} 
    		}
