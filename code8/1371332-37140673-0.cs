    public class WatermarkedTextbox : TextBox
    {
        private bool _isWatermarked;
        private string _watermark;
        public string Watermark
        {
            get { return _watermark; }
            set { _watermark = value; }
        }
        [Bindable(false), EditorBrowsable(EditorBrowsableState.Never), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override string Text
        {
            get
            {
                return _isWatermarked ? string.Empty : base.Text;
            }
            set
            {
                base.Text = value;
            }
        }
        public WatermarkedTextbox()
        {
            GotFocus += WatermarkedTextbox_GotFocus;
            LostFocus += WatermarkedTextbox_LostFocus;
        }
        private void WatermarkedTextbox_LostFocus(object sender, EventArgs e)
        {
            if (Text.Length == 0)
            {
                _isWatermarked = true;
                ForeColor = SystemColors.InactiveCaption;
                Text = _watermark;
            }
        }
        private void WatermarkedTextbox_GotFocus(object sender, EventArgs e)
        {
            if (_isWatermarked)
            {
                _isWatermarked = false;
                ForeColor = SystemColors.ControlText;
                Text = string.Empty;
            }
        }
    }
