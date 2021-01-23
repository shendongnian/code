     public List<string> YourList 
        {
            get
            {
                 if (_list[0] != "--Select--")
                    _list = _list.Insert(0, "--Select--");
                 return _list;
            }
        }
