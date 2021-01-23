    DateTime userBD = DateTime.Now; // let today be the b'day
    
    Dictionary<string, Timelimit> ZodiacSigns = new Dictionary<string, Timelimit>();
    ZodiacSigns.Add("Aquarius", new Timelimit()
    {
        startDate = new DateTime(userBD.Year, 01, 20),
        endDate = new DateTime(userBD.Year, 02, 18)
    });
    ZodiacSigns.Add("Pisces", new Timelimit()
    {
        startDate = new DateTime(userBD.Year, 03, 19),
        endDate = new DateTime(userBD.Year, 05, 20)
    });
    // Hence populate the dictonary from the developer side
    
    string star = ZodiacSigns.Where(x => 
                              userBD >= x.Value.startDate && 
                              userBD <= x.Value.endDate)
                              .FirstOrDefault().Key
