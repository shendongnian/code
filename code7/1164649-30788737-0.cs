            private DateTime _date;    
            
            public DateTime Date
            {
                get {
                    // by default the date was getting set to 1/1/0001 12:00:00 AM
                    if (_date == null || _date.ToString() == "1/1/0001 12:00:00 AM")
                    {
                        return _date = DateTime.Now;
                    }    
                    return _date; 
                }
                set {
                   
                    _date = value; 
                }
            }
