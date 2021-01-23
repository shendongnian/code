    public delegate IEnumerator YourFunction(Object obj);
    public YourFunction savedFunction;
    void Start() {
        savedFunction = MyIenum;
    }
    public IEnumerator MyIenum(Object obj) {
        // Do some stuff
    }
    public void ExecuteCoroutine() {
        StartCoroutine(savedFunction(new Object));
    }
