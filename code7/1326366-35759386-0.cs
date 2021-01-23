    public string SelectedName
        {
            get { return _SelectedName; }
            set
            {
                _SelectedName= value;
                this.RaisePropertyChanged("SelectedName");
                 
                // do your data retrieving form database ...
                CheckPrintYesOrNow();
            }
        }
