	public class HUDTableViewController : UIViewController, IUITableViewDataSource, IUITableViewDelegate, IDisposable
	{
		private UITableView tableView;
		public UITableView TableView
		{
			get
			{
				return this.tableView;
			}
			set
			{
				this.tableView = value;
			}
		}
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			this.tableView = new UITableView();
			this.tableView.TranslatesAutoresizingMaskIntoConstraints = false;
			this.tableView.WeakDelegate = this;
			this.tableView.WeakDataSource = this;
			UIView parentView = new UIView();
			parentView.AddSubview(this.tableView);
			View = parentView;
			NSMutableDictionary viewsDictionary = new NSMutableDictionary();
			viewsDictionary["parent"] = parentView;
			viewsDictionary["tableView"] = this.tableView;
			parentView.AddConstraints(NSLayoutConstraint.FromVisualFormat("H:|[tableView]|", (NSLayoutFormatOptions)0, null, viewsDictionary));
			parentView.AddConstraints(NSLayoutConstraint.FromVisualFormat("V:|[tableView]|", (NSLayoutFormatOptions)0, null, viewsDictionary));
		}
		[Foundation.Export("numberOfSectionsInTableView:")]
		public virtual System.nint NumberOfSections(UIKit.UITableView tableView)
		{
			throw new NotImplementedException();
		}
		public virtual System.nint RowsInSection(UIKit.UITableView tableview, System.nint section)
		{
			throw new NotImplementedException();
		}
		public virtual UIKit.UITableViewCell GetCell(UIKit.UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			throw new NotImplementedException();
		}
		[Foundation.Export("tableView:didSelectRowAtIndexPath:")]
		public virtual void RowSelected(UIKit.UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			throw new NotImplementedException();
		}
		[Foundation.Export("tableView:heightForHeaderInSection:")]
		public virtual System.nfloat GetHeightForHeader(UIKit.UITableView tableView, System.nint section)
		{
			throw new NotImplementedException();
		}
		[Foundation.Export("tableView:viewForHeaderInSection:")]
		public virtual UIKit.UIView GetViewForHeader(UIKit.UITableView tableView, System.nint section)
		{
			throw new NotImplementedException();
		}
		[Foundation.Export("tableView:willDisplayCell:forRowAtIndexPath:")]
		public virtual void WillDisplay(UIKit.UITableView tableView, UIKit.UITableViewCell cell, Foundation.NSIndexPath indexPath)
		{
			throw new NotImplementedException();
		}
	}
