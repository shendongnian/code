     public List<EmployeeData> LOP
     {
            get
            {
                if (_lop == null)
                {
                    _lop = new List<DTPackage>();
                }
                return _lop;
            }
            set
            {
                _lop = value;
            }
     }
    var lop = LOP; // here POP get will be called
