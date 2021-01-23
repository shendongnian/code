    public bool printInConsole;
    void Start()
    {
        Mss("Starting and printing..." );
    }
    private void Mss(string consoleMessage)
    {
        if (printInConsole)
            Debug.Log(consoleMessage + "\n");
    }
    
