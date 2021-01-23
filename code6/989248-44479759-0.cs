        public string Search
        {
            get { return _search; }
            set
            {
                if (_search == value)
                    return;
                _search = value;
                triggerSearch = false;
                Task.Run(async () =>
                {
                    string searchText = _search;
                    await Task.Delay(2000);
                    if (_search == searchText)
                    {
                        await ActionToFilter();
                    }
                });
            }
        }
