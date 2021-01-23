       private Boolean _textbox_enabled;
        public Boolean Textbox_Enabled
        {
            get { return _textbox_enabled; }
            set
            {
                _textbox_enabled = value; // You miss this line, could be ok to do an equality check here to. :)
                OnPropertyChanged("TextBoxEnabled");
            }
        }
