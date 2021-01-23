    public User[] users;
    
    var countryCount= users.ToList().GroupBy(n => n.Country).
                         Select(group =>
                             new
                             {
                                 Country= group.Key,
                                 Count = group.Count()
                             });
