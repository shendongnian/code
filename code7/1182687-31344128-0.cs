    public class ElipsisGroupBox : GroupBox
    {
        private string _tempText;
        private bool _isElipsisOn;
        public ElipsisGroupBox () : base()
	    {
            _tempText = string.Empty;
            _isElipsisOn = false;
	    }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (this.AutoElipsis)
            {
                _tempText = base.Text;
                if (_tempText.Length == 0 || base.Width == 0)
                    return;
                int i = _tempText.Length;
                string textToCheck = _isElipsisOn ? _tempText : _tempText + "...";
                _isElipsisOn = false;
                while (TextRenderer.MeasureText(textToCheck, base.Font).Width > (base.Width - 14))
                {
                    _isElipsisOn = true;
                    textToCheck = base.Text.Substring(0, --i) + "...";
                    if (i == 0)
                        break;
                }
                if (_isElipsisOn)
                    _tempText = textToCheck;
            }
        }
        public override string Text
        {
            get
            {
                return this.AutoElipsis && _isElipsisOn ? _tempText : base.Text;
            }
            set
            {
                if (this.AutoElipsis && _isElipsisOn)
                    _tempText = value;
                else
                    base.Text = value;
            }
        }
        public bool AutoElipsis { get; set; }
    }
