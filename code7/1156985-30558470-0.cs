	public partial class FollowForm : Form {
		#region Fields
		readonly Form _master;
		#endregion
		private FollowForm() {
			InitializeComponent();
		}
		public FollowForm(Form master) {
			if (master == null)
				throw new ArgumentNullException("master");
			_master = master;
			_master.LocationChanged += (s, e) => Location = _master.Location;
			_master.SizeChanged += (s, e) => Size = _master.Size;
			ShowInTaskbar = false;
		}
		protected override void OnShown(EventArgs e) {
			base.OnShown(e);
			SendToBack();
			Location = _master.Location;
			Size = _master.Size;
			_master.Activate();
		}
	}
