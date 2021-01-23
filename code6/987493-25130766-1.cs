    static someBase _trackingVar;
    public static someBase someProperty{ 
        get
        {
            if(_trackingVar == null){
                _trackingVar = GetBase(...);
            }
            return _trackingVar;
        }
    }
