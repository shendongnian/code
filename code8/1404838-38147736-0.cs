    private string _sqlAlias;
    public string SqlAlias {
         get {
             if (_sqlAlias == null) {
                 _sqlAlias = GetColumnName();
             }
         
             return _sqlAlias;
         }
    }
  
