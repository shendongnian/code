    public class CustomLabel : Label
	{
	// Constructors
		// Default Constructor
		public CustomLabel() : base() { }
		public CustomLabel(bool drawBorder, int borderThickness, Color borderColor, Color textColor) : base()
		{
			if (drawBorder)
			{
				BorderThickness = borderThickness;
				BorderColor = borderColor;
			}
			Size = new Size(36, 36);
			Text = "Info";
			Anchor = (AnchorStyles.Left | AnchorStyles.Right);
			AutoSize = false;
			TextAlign = ContentAlignment.MiddleCenter;
			Enabled = false;
			Font = new Font("Microsoft Sans Serif", 6);
			ForeColor = TextColor;
			BorderStyle = BorderStyle.FixedSingle;
			Dock = DockStyle.Fill;
			
		}
		// Creates a border of specified thickness and color
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			if (BorderStyle == BorderStyle.FixedSingle)
			{
				int halfThickness = BorderThickness / 2;
				using (Pen p = new Pen(BorderColor, BorderThickness))
				{
					e.Graphics.DrawRectangle(p, new Rectangle(halfThickness,
						 halfThickness,
						 ClientSize.Width - BorderThickness, ClientSize.Height - BorderThickness));
				}
			}
		}
		public int BorderThickness { get; set; }
		public Color BorderColor { get; set; }
	}
