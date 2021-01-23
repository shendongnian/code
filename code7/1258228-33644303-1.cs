    //constructor
    public Datapoint(
        bool? debug = null, 
        string pattern = null,
        List<Dictionary<string, dynamic>> operations = null
    )
    {
        Debug = debug.HasValue && debug.Value;
        Pattern = pattern;
        this.operations = (operations == null) ? 
                  new List<Dictionary<string, dynamic>>() 
                  : operations ;
    }
