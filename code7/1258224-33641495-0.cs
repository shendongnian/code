    public Datapoint(
        bool debug = false, 
        string pattern = "",
        List<Dictionary<string, dynamic>> operations = null
    )
    {
        Debug = debug;
        Pattern = pattern;
        if (operations == null)
        {
            this.operations = new List<Dictionary<string, dynamic>>();
        }
    }
