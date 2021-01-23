	using System.Drawing;
	using System.Windows.Forms;
	namespace WinformsScratch.RubberBand
	{
		public class TestY : Control
		{
			private Point? _selectionStart;
			private Point? _selectionEnd;
			private readonly Pen _selectionPen;
			public TestY()
			{
				_selectionPen = new Pen(Color.Black, 3.0f);
				SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
				MouseDown += (s, e) => {
					if (e.Button == MouseButtons.Left) 
						_selectionStart = _selectionEnd = e.Location;
				};
				
				MouseUp += (s, e) => {
					if (e.Button == MouseButtons.Left) 
					{
						_selectionStart = _selectionEnd = null; 
						Invalidate(false); 
					}
				};
				
				MouseMove += (s, e) => {
					if (_selectionStart.HasValue &&
						_selectionEnd.HasValue &&
						_selectionEnd.Value != e.Location)
					{
						_selectionEnd = e.Location;
						Invalidate(false);
					}
				};
				Paint += (s, e) => {
					if (_selectionStart.HasValue && _selectionEnd.HasValue)
						e.Graphics.DrawRectangle(_selectionPen, GetSelectionRectangle());
				};
			}
			protected override void Dispose(bool disposing)
			{
				if (disposing)
				{
					if (_selectionPen != null) _selectionPen.Dispose();
				}
				base.Dispose(disposing);
			}
			private Rectangle GetSelectionRectangle()
			{
				Rectangle rc = new Rectangle();
				if (_selectionStart.HasValue && _selectionEnd.HasValue)
				{
					// Normalize the rectangle.
					if (_selectionStart.Value.X < _selectionEnd.Value.X)
					{
						rc.X = _selectionStart.Value.X;
						rc.Width = _selectionEnd.Value.X - _selectionStart.Value.X;
					}
					else
					{
						rc.X = _selectionEnd.Value.X;
						rc.Width = _selectionStart.Value.X - _selectionEnd.Value.X;
					}
					if (_selectionStart.Value.Y < _selectionEnd.Value.Y)
					{
						rc.Y = _selectionStart.Value.Y;
						rc.Height = _selectionEnd.Value.Y - _selectionStart.Value.Y;
					}
					else
					{
						rc.Y = _selectionEnd.Value.Y;
						rc.Height = _selectionStart.Value.Y - _selectionEnd.Value.Y;
					}
				}
				return rc;
			}
		}
	}
