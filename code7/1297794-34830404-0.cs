     private ObservableCollection<Url> _uriList = new ObservableCollection<Url()
        {
            new Url() { domain = "www.test2.com" }
        };
        public bool UrlList
        {
            get
            {
                return _uriList;
            }
            set
            {
                if (_uriList == value)
                {
                    return;
                }
                _uriList = value;
                
            }
        }
