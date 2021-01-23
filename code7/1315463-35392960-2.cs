        private bool _isNeedCrawle;
        public bool IsNeedCrawle
        {
            get
            {
                return _isNeedCrawle;
            }
            set
            {
                if (_isNeedCrawle != value)
                {
                    _isNeedCrawle = value;
                    if (_isNeedCrawle)
                    {
                        startCrawling();
                    }
                    NotifyPropretyChanged("IsNeedCrawle");
                }
            }
        }
