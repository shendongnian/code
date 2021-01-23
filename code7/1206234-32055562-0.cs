    private Dictionary<Vector3, bool> _isZoneEmpty = new Dictionary<Vector3, bool> ();
    
    public Dictionary<Vector3, bool> IsZoneEmpty { 
        get
        {
            return _isZoneEmpty;
        }
        set 
        {
            _isZoneEmpty = value;
        }
    }
