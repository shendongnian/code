    public class TransparentControl : Control
    {
        public TransparentControl()
        {
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }
        private const int WS_EX_TRANSPARENT = 0x20;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle = cp.ExStyle | WS_EX_TRANSPARENT;
                return cp;
            }
        }
    }
