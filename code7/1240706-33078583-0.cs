        private object obj = new object();
        private static ConcurrentDictionary<int, string> _contactIdNames;
        public ConcurrentDictionary<int, string> ContactIdNames
        {
            get
            {
                if (!_isBusyUpdating) return _contactIdNames;
                return _contactIdNamesOld;
            }
            set 
            {
                if(_isBusyUpdating) _contactIdNamesOld = 
                    new ConcurrentDictionary<int, string>(_contactIdNames);
                _contactIdNames = value; 
            }
        }
