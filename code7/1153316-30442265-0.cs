	using System;
	using System.Windows.Forms;
	using System.Drawing;
	using System.Drawing.Drawing2D;
	public class CircularProgressBar : Control
	{
		#region "Properties"
		private Color _BorderColor;
		public Color BorderColor
		{
			get { return _BorderColor; }
			set
			{
				_BorderColor = value;
				this.Invalidate();
			}
		}
		private Color _InnerColor;
		public Color InnerColor
		{
			get { return _InnerColor; }
			set
			{
				_InnerColor = value;
				this.Invalidate();
			}
		}
		private bool _ShowPercentage;
		public bool ShowPercentage
		{
			get { return _ShowPercentage; }
			set
			{
				_ShowPercentage = value;
				this.Invalidate();
			}
		}
		private int _BorderWidth;
		public int BorderWidth
		{
			get { return _BorderWidth; }
			set
			{
				_BorderWidth = value;
				this.Invalidate();
			}
		}
		private float _Value;
		public float Value
		{
			get { return _Value; }
			set
			{
				_Value = value;
				this.Invalidate();
			}
		}
		#endregion
		#region "Constructor"
		public CircularProgressBar()
		{
			SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			SetStyle(ControlStyles.ResizeRedraw, true);
			SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
			_Value = 100;
			_BorderColor = Color.Orange;
			_BorderWidth = 30;
			_ShowPercentage = true;
			_InnerColor = Color.DarkGray;
			this.ForeColor = Color.White;
		}
		#endregion
		#region "Painting"
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
			//Measure the single parts
			int Diameter = Math.Min(this.ClientSize.Width, this.ClientSize.Height);
			int InnerDiameter = Diameter - BorderWidth;
			Rectangle PieRect = new Rectangle(Convert.ToInt32(this.ClientSize.Width / 2 - Diameter / 2), Convert.ToInt32(this.ClientSize.Height / 2 - Diameter / 2), Diameter, Diameter);
			Rectangle InnerRect = new Rectangle(Convert.ToInt32(this.ClientSize.Width / 2 - InnerDiameter / 2), Convert.ToInt32(this.ClientSize.Height / 2 - InnerDiameter / 2), InnerDiameter, InnerDiameter);
			//Draw outer ring
			using (SolidBrush b = new SolidBrush(BorderColor))
			{
				e.Graphics.FillPie(b, PieRect, 0, Value / 100 * 360);
			}
			//Draw inner ring
			using (SolidBrush b = new SolidBrush(this._InnerColor))
			{
				e.Graphics.FillEllipse(b, InnerRect);
			}
			//Draw percentage
			if (ShowPercentage)
			{
				using (StringFormat sf = new StringFormat())
				{
					sf.Alignment = StringAlignment.Center;
					sf.LineAlignment = StringAlignment.Center;
					using (SolidBrush b = new SolidBrush(this.ForeColor))
					{
						e.Graphics.DrawString(Convert.ToInt32(Value).ToString() + "%", this.Font, b, InnerRect, sf);
					}
				}
			}
		}
		#endregion
	}
