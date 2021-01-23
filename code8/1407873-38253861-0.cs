    public static dynamic GetValue()
    {
        dynamic person = new ExpandoObject();
        person.OilChange = true;
        person.Lube = 30;
        person.Job = "Brakes";
    
        return person;
    }
