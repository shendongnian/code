	public partial class TransTextBox : TextBox {
		public TransTextBox() {
			SetStyle(ControlStyles.SupportsTransparentBackColor |
				//ControlStyles.OptimizedDoubleBuffer | //comment this flag out
							 ControlStyles.AllPaintingInWmPaint |
							 ControlStyles.ResizeRedraw |
							 ControlStyles.UserPaint, true);
			BackColor = Color.Transparent;
		}
		private void redrawText() {
			using (Graphics graphics = this.CreateGraphics())
			using (SolidBrush brush = new SolidBrush(this.ForeColor))
				graphics.DrawString(this.Text, this.Font, brush, 1, 1); //play around with how you draw string more to suit your original
		}
		protected override void OnPaint(PaintEventArgs e) {
			base.OnPaint(e);
			redrawText();
		}
	}
