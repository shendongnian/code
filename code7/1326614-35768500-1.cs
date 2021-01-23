    public Person[] search_bustype(string match, string forthat)
    {
        var db = new rkdb_07022016Entities2();
        List<Person> personList = new List<Person>();
        foreach (var toCheck in db.tblbus_business.Where(b => b.BusType.ToString() == match))
        {
            var model = new Person { Name = toCheck.Name, Address = toCheck.Address };
            personList.Add(model);        
       }
       return personList.ToArray();
    }
