    private List<object> _Collection1; //The original collection
    private List<object> _FilteredCollection1; //The filtered collection
    public List<object> FilteredCollection1
    {
        get { return _FilteredCollection1; }
        set
        {
            _FilteredCollection1 = value;
            //Notify property changed.
        }
    }
    //Some more collections
    ...
