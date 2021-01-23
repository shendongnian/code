    class State : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private bool _checked;
        public bool Checked
        {
            get { return _checked; }
            set { _checked = value; OnPropertyChanged(); }
        }       
        public void Toggle()
        {
            Checked = !Checked;
        }
        public State(bool c)
        {
            this.Checked = c;
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
