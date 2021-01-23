    public JObject GetTests()
    {
        
        NewtonSoft.Json.Linq.JObject jsonResult = NewtonSoft.Json.Linq.JObject.FromObject(new 
        {
            Tests = from test in db.tests
                    select new 
                    {
                        Id = test.Id,
                        Title = test.Title,
                        Users = from user in test.Users
                                select new
                                {
                                    Id = user.Id
                                }
                    }
        });
        
        return jsonResult;
    }
