    public partial class CustomCell : UITableViewCell {
    		
    EventHandler _likeButtonHandler;
		public static readonly NSString Key = new NSString (typeof(CustomCell).Name);
		public static readonly UINib Nib = UINib.FromName (typeof(CustomCell).Name, NSBundle.MainBundle);
		public CustomCell ()
		{
		
		}
		public CustomCell (IntPtr handle) : base (handle)
		{
		}
		public override void PrepareForReuse ()
		{
			LikeButton.TouchUpInside -= _likeButtonHandler;
			_likeButtonHandler = null;
			base.PrepareForReuse ();
		}
		public void SetupCell (int row, string Name, EventHandler likeBtnHandler)
		{
			_likeButtonHandler = likeBtnHandler;
			LikeButton.TouchUpInside += _likeButtonHandler;
			LikeButton.Tag = row;
			NameLabel.Text = Name;
			RowLabel.Text = row.ToString ();
		}
	}
