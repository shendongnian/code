    public partial class trLabel : Label
    {
        public trLabel()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
            BackColor = Color.Transparent;
            Visible = true;
            AutoSize = true;
        }
    }
