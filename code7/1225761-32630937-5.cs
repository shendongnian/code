    [HttpPost]
    public string Post([FromBody]parameters parameters)
    {
           var initial = new parameters {bar = "a", foo = "a", widget = "a"};
           initial.RegisterObject();
           var changed = new parameters {bar = "v", foo = "a", widget = "a"};
           string bChanged=  changd.CheckChanges();
    }
