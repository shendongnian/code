            private List<KeyValuePair<string, string>> _data = new List<KeyValuePair<string, string>>();
            public List<KeyValuePair<string, string>> DataKvp
            {
                get { return _data;}
                set { _data = value; }
            }
            private String[][] _dataArray;
            [DataMember(Name = "data", EmitDefaultValue = false)]
            public String[][] DataArray
            {
                get
                {
                    _dataArray = new string[_data.Count][];
                    var i = 0;
                    for (var index = 0; index < _data.Count; index++)
                    {
                        var pair = _data[index];
                        _dataArray[i] = new[] { pair.Key, pair.Value };
                        i++;
                    }
                    return _dataArray;
                }
            }
