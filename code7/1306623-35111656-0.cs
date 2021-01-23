    [HttpPost]
    public void AddEmployee([FromBody]Models.Employee user)
    {
       EService eserv = new EService();
        eserv.Addemp(user);
    }
