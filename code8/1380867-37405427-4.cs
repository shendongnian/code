    static void Main(string[] args)
    {
        Cust customer = new Cust() { Name = "aa", CNIC = "bb" };
        string jsonResult = JsonConvert.SerializeObject(customer);
    
        var props = typeof(Cust).GetProperties().ToList();
    
        foreach(var prop in props)
        {
            string oldPropJosn = String.Format("\"{0}\":", prop.Name);
            string newPropJson = String.Format("\"{0}.{1}\":", nameof(Cust), prop.Name);
            jsonResult = jsonResult.Replace(oldPropJosn, newPropJson);
        }
    }
