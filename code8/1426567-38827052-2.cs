    public string ConvertJSON()
    {
        Person p = new Person();
        p.FirstName = "Khan";
        p.LastName = "Imran";
        return json = JsonConvert.SerializeObject(p);
    }
