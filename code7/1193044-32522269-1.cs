     private Visibility _visible;
        public Visibility Visible //Binding to this in Listbox - Button Visibility
        {
            get { return _visible; }
            set { _visible = value; } //Call OnPropertyChanged method
        }
