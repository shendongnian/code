	public partial class FeeViewCell : UITableViewCell, INativeElementView
	{
		public static readonly NSString Key = new NSString(nameof(FeeViewCell));
		Element _element;
    public Element Element
    		{
    			get { return _element; }
    			set { _element = value; }
    		}
    }
