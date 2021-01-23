    public HttpResponseMessage PostFilter([FromBody] dynamic data)
    {
        string[] vendorname = data.vendorname != null
                              ? data.vendorname.ToObject<string[]>()
                              : null;
    
        var query = context.AllInventories;
        if (vendorname != null)
        {
            query = context.AllInventories.Where(s => vendorname.Contains(s.VENDORNAME));
        }
    
        var items = query.Take(500).ToList();
    }
