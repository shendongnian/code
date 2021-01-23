      private bool _IsNeedToOpen = false;
        public bool IsNeedToOpen
        {
            get { return _IsNeedToOpen; }
            set
            {
                if (_IsNeedToOpen == value) { return; }
                _IsNeedToOpen = value;
                OnPropertyChanged("IsNeedToOpen");
            }
        }
        private void TextBox_GotKeyboardFocus(object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e)
        {
            IsNeedToOpen = true;
        }
    
           
