    class State : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private bool _checked;
        public bool Checked
        {
            get
            {
                return _checked;
            }
            set
            {
                _checked = value;
                OnPropertyChanged("Checked");
            }
        }
        public void Toggle()
        {
            if (!Checked)
            {
                Checked = true;
            }
            else
            {
                Checked = false;
            }
        }
        public State(bool c)
        {
            this.Checked = c;
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
 
