    public Dictionary<string, string> MyDictionary { get; set; }
    
    void genMyDict()
    {
        MyDictionary = new Dictionary<string, string>();
        MyDictionary.Add("@x.com", "x");
        ...
    }
    void Archive()
    {
        if (MyDictionary.ContainsKey("@x.com")) { // run code }
    }
