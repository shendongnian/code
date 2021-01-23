	[Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
	public partial class MovableContainer : UserControl
	{
		bool mdown = false;
		Point mpos;
		int rasta;
		Control parent;
		[EditorBrowsable(EditorBrowsableState.Always)]
		[SettingsBindable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public Axis Rasta { get; set; }
		public static int DefautlRasta = 10;
		public MovableContainer()
		{
			rasta = DefautlRasta;
			InitializeComponent();
			this.MouseDown += (sender, e) =>
			{
				mdown = true;
				mpos = e.Location;
			};
			this.MouseUp += (sender, e) =>
			{
				mdown = false;
			};
			this.MouseMove += (sender, e) =>
			{
				if (mdown)
					SetLocation(this.Location.Add(e.Location.Sub(mpos)).Rasta(Rasta, rasta));
			};
			EventHandler onParentSizeChanged = (sender, e) =>
			{
				SetLocation(this.Location);
			};
			this.ParentChanged += (sender, e) =>
			{
				if (parent != null) parent.SizeChanged -= onParentSizeChanged;
				parent = Parent;
				if (parent != null) parent.SizeChanged += onParentSizeChanged;
			};
		}
		private void SetLocation(Point location)
		{
			var rect = new Rectangle(location, Size);
			var clipRect = Parent.DisplayRectangle;
			if (rect.Right > clipRect.Right) rect.X -= (rect.Right - clipRect.Right);
			if (rect.X < clipRect.X) rect.X = clipRect.X;
			if (rect.Bottom > clipRect.Bottom) rect.Y -= (rect.Bottom - clipRect.Bottom);
			if (rect.Y < clipRect.Y) rect.Y = clipRect.Y;
			location = rect.Location;
			if (this.Location == location) return;
			this.Location = location;
		}
	}
	public enum Axis { X, Y, None }
    // You haven't provided these, so I'm guessing by the usage 
	static class Utils
	{
		public static Point Add(this Point left, Point right)
		{
			return new Point(left.X + right.X, left.Y + right.Y);
		}
		public static Point Sub(this Point left, Point right)
		{
			return new Point(left.X - right.X, left.Y - right.Y);
		}
		public static Point Rasta(this Point pt, Axis axis, int value)
		{
			// Have absolutely no idea what is this about
			return pt;
		}
	}
