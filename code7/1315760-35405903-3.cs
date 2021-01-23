    class MyControl0 : Control
    {
        private SolidBrush foreColor = new SolidBrush(SystemColors.ControlText);
        public override Color ForeColor
        {
            get { return foreColor.Color; }
            set { foreColor.Color = value; }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
 	         base.OnPaint(e);
            TextFormatFlags flags = TextFormatFlags.HorizontalCenter |
                                    TextFormatFlags.VerticalCenter ;
            TextRenderer.DrawText(e.Graphics, Text, Font, ClientRectangle, 
                                  ForeColor, flags);
        }
    }
