    public void FindTheStringImLookingFor()
    {
        var linhas = new List<string>();
        linhas.Add("123;abc");
        linhas.Add("456;def");
        linhas.Add("789;ghi");
        linhas.Add("chocolate");
        var words = linhas.Where(GetTheStringIWant);
    }
    private bool GetTheStringIWant(string s)
    {
        var parts = s.Split(':');
        // Do a lot of other operations that take a few lines.
        return parts.Length > 1 ? parts[1] == "def" : false;
    }
