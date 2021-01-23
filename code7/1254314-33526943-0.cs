    		public void RemoveTopRow()
    		{
    			dataSource.Objects.RemoveAt (0);
    			TableView.ReloadData ();
    		}
    
    		void AddNewItem (object sender, EventArgs args)
    		{
    			dataSource.Objects.Add (DateTime.Now);
    
    			// This will cause the error that you are seeing
    			//if (dataSource.Objects.Count > 10) {
    			//	RemoveTopRow ();
    			//}
    
    			using (var indexPath = NSIndexPath.FromRowSection (0, 0))
    				TableView.InsertRows (new [] { indexPath }, UITableViewRowAnimation.Automatic);
    
    			//This will work
    			if (dataSource.Objects.Count > 10) {
    				RemoveTopRow ();
    			}
    		}
