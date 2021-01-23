    private string _name;
    public string Name {
    get { return ((this._name != "" && this._name != null ) ? this._name.Trim():this._name); }
    set { this._name = (value == null) ? "" : value.Trim(); }
    }
     
