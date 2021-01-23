        public ObservableCollection<ITimeLineDataItem> ListBoxData
        {
            get
            {
                return this.listboxData;
            }
            set
            {
                    this.listboxData = value;
                    this.RaisePropertyChanged(() => this.ListBoxData);
                
            }
        }
