    private string _specialString;
    public string SpecialString{
        get;
        set{
            if(value.Length < 5)
            {
                throw new Exception();
            }
            else
            {
                this._specialstring = value;
            }
    }
        
