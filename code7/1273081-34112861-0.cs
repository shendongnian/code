            private ObservableCollection<Grouping<String, Request>> _groupedList = null;
            public ObservableCollection<Grouping<String, Request>> GroupedList
            {
                get
                {
                    return _groupedList;
                }
                set
                {
                    _groupedList = value;
                    RaisePropertyChanged(() => GroupedList);
                }
            }
