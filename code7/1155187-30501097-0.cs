    public class ValidateEdit : TextBox
    {
        bool _InError;
        
        public ValidateEdit()
        {
            SetStyle(ControlStyles.UserPaint, true);
        }
        public bool InError {
            get {
                return _InError;
            }
            set
            {
                _InError = value;
                Refresh();
            }
        }
        
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (InError)
                ControlPaint.DrawBorder(e.Graphics, this.DisplayRectangle, Color.Red, ButtonBorderStyle.Solid);
        }
    }
