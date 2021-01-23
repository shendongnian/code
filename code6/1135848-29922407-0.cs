    public class CustomTableView : UITableView
    {
    	static readonly NSString MyCellId = new NSString ("CustomTableViewCell");
    
    	public CustomTableView ()
    	{
    		RegisterClassForCellReuse(typeof(CustomTableViewCell), MyCellId);
    		Source = new CustomDataSource();
    	}
    }
