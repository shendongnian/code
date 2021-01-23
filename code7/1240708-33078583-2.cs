        private object obj = new object();
        private ConcurrentDictionary<int, string> _contactIdNames;
        private ConcurrentDictionary<int, string> _contactIdNamesOld;
        private volatile bool _isBusyUpdating = false;
        public ConcurrentDictionary<int, string> ContactIdNames
        {
            get
            {
                if (!_isBusyUpdating) return _contactIdNames;
                return _contactIdNamesOld;
            }
            private set 
            {
                if(_isBusyUpdating) _contactIdNamesOld = 
                    new ConcurrentDictionary<int, string>(_contactIdNames);
                _contactIdNames = value; 
            }
        }
