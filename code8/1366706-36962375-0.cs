            private List<string> _list = new List<string>();
    
            public void SetData(string value)
            {
                if (this._list.Count() < 10)
                {
                    this._list.Add(value);
                }
            }
    
            public List<string> GetList()
            {
                return this._list;
            } 
