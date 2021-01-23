    public MyResultData Post([FromBody] MyQueryData queryData)
    {
        if (!this.Request.Properties.ContainsKey("MS_HttpConfiguration")) 
        {
            this.Request.Properties["MS_HttpConfiguration"] = new HttpConfiguration();
        }
        this.Validate(queryData);
        if (ModelState.IsValid)
        {
            DoSomething();
        }
    }
