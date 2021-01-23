    public partial class ViewController : UIViewController
	{
		protected ViewController (IntPtr handle) : base (handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.
			CGRect tableFrame = this.View.Bounds;
			tableFrame.Y = 100;
			tableFrame.Height -= 100;
			UITableView tableView = new UITableView (tableFrame);
			this.View.AddSubview (tableView);
			MyTalbeSource mySource = new MyTalbeSource ();
			tableView.Source = mySource;
			tableView.ReloadData ();
			int count = 0;
			UIButton btnNew = new UIButton (UIButtonType.System);
			btnNew.Frame = new CGRect (20, 20, 100, 40);
			btnNew.SetTitle ("NewItem", UIControlState.Normal);
			btnNew.TouchUpInside += delegate {
				mySource.AddNewItem ("NewItem" + count++);
				tableView.ReloadData ();
			};
			this.Add (btnNew);
		}
	}
	class MyTalbeSource : UITableViewSource
	{
		private const string CELL_ID = "MyTalbeCell";
		private List<string> dataList;
		public MyTalbeSource ()
		{
			dataList = new List<string> ();
			for (int i = 0; i < 5; i++) {
				dataList.Add ("Test " + i.ToString ());
			}
		}
		public void AddNewItem (string title)
		{
			dataList.Add (title);
		}
		public override nint RowsInSection (UITableView tableview, nint section)
		{
			return dataList.Count;
		}
		public override UITableViewCell GetCell (UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			MyTableCell cell = tableView.DequeueReusableCell (CELL_ID) as MyTableCell;
			if (null == cell) {
				cell = new MyTableCell (UITableViewCellStyle.Default, CELL_ID);
				cell.InitCell ();
			}
			cell.Text = dataList [indexPath.Row];
			return cell;
		}
	}
	class MyTableCell : UITableViewCell
	{
		private UILabel lbInfo;
		public string Text { 
			get {
				return lbInfo.Text;
			}
			set {
				lbInfo.Text = value;
			}
		}
		public MyTableCell (UITableViewCellStyle style, string cellID) : base (style, cellID)
		{
		}
		public void InitCell ()
		{
			lbInfo = new UILabel ();
			lbInfo.TextAlignment = UITextAlignment.Center;
			this.AddSubview (lbInfo);
		}
		public override void LayoutSubviews ()
		{
			lbInfo.Frame = this.Bounds;
		}
	}
