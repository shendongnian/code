    Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
    private void ProductList_Load(object sender, EventArgs e)
    {
        //Initialize dictionary with keys and values
        dictionary["page1"] = new List<string> { "string 1", "string 2" };
        dictionary["page2"] = new List<string> { "string 3", "string 4" };
        //...
    }
