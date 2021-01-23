            public string TextKomentar
        {
            get
            {
                return this.textKomentar;
            }
            set
            {
                // Implement with property changed handling for INotifyPropertyChanged
                if (!string.Equals(this.textKomentar, value))
                {
                    textKomentar = value;
                    OnPropertyChanged("TextKomentar");
                }
                ButtonCommand.RaiseCanExecuteChanged();
            }
        }
