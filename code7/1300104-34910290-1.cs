    class CustomProgressBar : ProgressBar {
        public CustomProgressBar() : base() {}
        protected override void OnPaint(PaintEventArgs e) {
            // Call the OnPaint method of the base class.
            base.OnPaint(e);
            string percentStr = this.Value.ToString() + "%";
            PointF location = new PointF(this.Width / 2 - 10, this.Height / 2 - 7);
            // Call methods of the System.Drawing.Graphics object.
            e.Graphics.DrawString(percentStr, new Font("Arial",10), Brushes.Red, location );
        } 
    }
