        public event TextChangedEventHandler TextChanged;
        private string _Text;
        public string Text
        {
            set
            {
                var previousText = _Text;
                _Text = value;
                if (TextChanged != null)
                {
                    var args = new TextChangedEventArgs(previousText, value);
                    TextChanged(this, args);
                }
            }
            get
            {
                return _Text;
            }
        }
