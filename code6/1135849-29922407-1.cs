    public class CustomTableViewCell : UITableViewCell
    {
		public CustomTableViewCell (IntPtr handle) : base (handle)
		{}
		public Load(object[] data){
			//Create custom view in code
			var title = new UILabel();
			// etc.
			// Or pull in from an XIB
			UINib Nib = UINib.FromName ("CustomViewCell_iPad", NSBundle.MainBundle);
		}
    }
