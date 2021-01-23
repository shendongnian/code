    public Datapoint(
        bool debug = false, 
        string pattern = "",
        List<Dictionary<string, dynamic>> operations = null
    )
    {
        Debug = debug;
        Pattern = pattern;
        this.operations = operations ?? new List<Dictionary<string, dynamic>>();
    }
