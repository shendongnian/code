    public static event EventHandler<String> MyAppNameChanged;
    private static String _myAppName = "";
    public static String MyAppName {
        get { return _myAppName; }
        set {
            if (_myAppName != value)
            {
                _myAppName = value;
                //  C#6 again
                MyAppNameChanged?.Invoke(this, value);
            }
        }
    }
