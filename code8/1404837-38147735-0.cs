    private string _sqlAlias = null;
    public string SqlAlias {
        get {
           if (_sqlAlias == null)
               _sqlAlias = this.GetColumnName();
           return _sqlAlias;
        } 
    }
