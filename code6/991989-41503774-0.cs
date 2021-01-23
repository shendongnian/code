    public class MyTableSource : UITableViewSource
	{
		string SectionIndentifer = "mySection";
		string CellIndentifer = "myCell";
        
        public List<MyItem> vList { get; set; }
		List<bool> expandStatusList; // Maintain a list which keeps track if a section is expanded or not
        public MeasurementsDetailsTableSource (List<MyItem> vList)
		{
			this.vList = vList;
            expandStatusList = new List<bool> ();
            for (int i = 0; i < vList.Count; i++) {
                expandStatusList.Add (false); // Initially, no section are expanded
            } 
		}
        public override nint NumberOfSections (UITableView tableView)
		{
			return vList.Count;
		}
		public override nint RowsInSection (UITableView tableview, nint section)
		{
			if (!expandStatusList [(int)section])
				return 0; // Returning 0 to hide all the rows of the section, there by collapsing the section.
			return vList [(int)section].subItems.Count; 
		}
        public override UIView GetViewForHeader (UITableView tableView, nint section)
		{
			UITableViewCell cell = tableView.DequeueReusableCell (SectionIndentifer);
			if (cell == null) {
				cell = new UITableViewCell (UITableViewCellStyle.Default, SectionIndentifer);
			}
            ...
            // Settings up a click event to section to expand the section..
            var gesture = new UITapGestureRecognizer ();
			gesture.AddTarget (() => ParentClick (gesture));
			cell.AddGestureRecognizer (gesture);
            cell.Tag = section; // This is needed to indentify the section clicked..
            return cell;
         }
         public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		 {
			 UITableViewCell cell = tableView.DequeueReusableCell (CellIndentifer);
			 if (cell == null) {
				cell = new UITableViewCell (UITableViewCellStyle.Default, CellIndentifer);
			 }
             ...
			 return cell;
		 }
         public void ParentClick (UITapGestureRecognizer gesture)
		 {
		 	 NSIndexPath indexPath = NSIndexPath.FromRowSection (0, gesture.View.Tag);
		 	 if (indexPath.Row == 0) {
				 if (vList [indexPath.Section].mValues.Count != 0) {
					 bool expandStatus = expandStatusList [indexPath.Section];
					 for (int i = 0; i < vList.Count; i++) {
						 if (indexPath.Section == i) {
							 expandStatusList [i] = !expandStatus;
						 }
					 }
					 tableView.ReloadSections (NSIndexSet.FromIndex (gesture.View.Tag), UITableViewRowAnimation.Automatic);
					 tableView.ReloadData ();
					 return;
				 }
			 }
		 }
     }
