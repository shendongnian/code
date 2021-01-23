    // constructor
    public Datapoint(bool debug = false, 
                string pattern = "")
    {
        Debug = debug;
        Pattern = pattern;
        operations = new List<Dictionary<string, dynamic>>();
    }
    public Datapoint(bool debug = false, 
                string pattern = "",
                List<Dictionary<string, dynamic>>() operations)
    {
        Debug = debug;
        Pattern = pattern;
        this.operations = operations;
    }
