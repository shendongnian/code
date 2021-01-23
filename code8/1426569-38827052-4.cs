    public string ConvertJSON()
    {
        Person p = new Person();
        p.FirstName = "Khan";
        p.LastName = "Imran";
        string json = "";
        return json = JsonConvert.SerializeObject(p);
    }
