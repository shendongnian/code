    public class WatermarkedTextbox : TextBox, INotifyPropertyChanged
    {
        private bool _isWatermarked;
        private string _watermark;
        public string Watermark
        {
            get { return _watermark; }
            set { _watermark = value; }
        }
        public bool IsWaterMarked
        {
            get
            {
                return _isWatermarked;
            }
            set
            {
                _isWatermarked = value;
                OnPropertyChanged("IsWaterMarked");
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
                ForeColor = SystemColors.InactiveCaption;
                Text = _watermark;
                IsWaterMarked = true;
            }
        }
        private void WatermarkedTextbox_GotFocus(object sender, EventArgs e)
        {
            if (_isWatermarked)
            {
                ForeColor = SystemColors.ControlText;
                Text = string.Empty;
                IsWaterMarked = false;
            }
        }
        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, e);
        }
        protected void OnPropertyChanged(string propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
