	public class MyGlyph : Glyph
	{
		private readonly BehaviorService m_BehaviorService;
		private readonly Control m_Control;
		public int Issues { get; set; }
		public Control Control { get { return m_Control; } }
		public VolkerIssueGlyph(BehaviorService behaviorService, Control control) : base(new MyBehavior())
		{
			m_Control = control;
			m_BehaviorService = behaviorService;			
		}
		public override Rectangle Bounds
		{
			get
			{
				Point p = m_BehaviorService.ControlToAdornerWindow(m_Control);
				Graphics g = Graphics.FromHwnd(m_Control.Handle);
				SizeF size = g.MeasureString(Issues.ToString(), m_Font);
				return new Rectangle(p.X + 1, p.Y + m_Control.Height - (int)size.Height - 2, (int)size.Width + 1, (int)size.Height + 1);
			}
		}
		public override Cursor GetHitTest(Point p)
		{
			return m_Control.Visible && Bounds.Contains(p) ? Cursors.Cross : null;
		}
		public override void Paint(PaintEventArgs pe)
		{
			if (!m_Control.Visible) return;
			Point topLeft = m_BehaviorService.ControlToAdornerWindow(m_Control);
			using (Pen pen = new Pen(Color.Red, 2))
				pe.Graphics.DrawRectangle(pen, topLeft.X, topLeft.Y, m_Control.Width, m_Control.Height);
			Rectangle bounds = Bounds;
			pe.Graphics.FillRectangle(Brushes.Red, bounds);
			pe.Graphics.DrawString(Issues.ToString(), m_Font, Brushes.Black, bounds);
		}
	}
