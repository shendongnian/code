    private string _count;
    public string count { 
        get { return _count; } 
        set {
            if(value != _count) {
                _count = value;
                onPropertyChanged("count");
            }
        } 
    }
    private int _testCount = 0;
    public void Method() {
        testCount++;
        Debug.WriteLine(testCount.ToString());
        count = testCount.ToString();
    }
