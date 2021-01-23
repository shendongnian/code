    private int _GreenValue;
    private int _RedValue;
    private int _BlueValue;
    private Color _BackGroundColor;
    
    
    public int GreenValue
    {
        get { return _GreenValue; }
        set
        {
            _GreenValue = value;
            _BackGroundColor = Color.FromArgb(_RedValue, _GreenValue, _BlueValue);
        }
    }
    public int MyProperty
    {
        get { return _RedValue; }
        set
        {
            _RedValue = value;
            _BackGroundColor = Color.FromArgb(_RedValue, _GreenValue, _BlueValue);
        }
    }
    public int BlueValue
    {
        get { return _BlueValue; }
        set
        {
            _BlueValue = value;
            _BackGroundColor = Color.FromArgb(_RedValue, _GreenValue, _BlueValue);
        }
    }
        
    public Color BackGroundColor
    {
        get { return _BackGroundColor; }
    }
