    var foo = new List<DateTime>()
    {
        DateTime.Now.AddMinutes(10),
        DateTime.Now.AddMinutes(15),
        DateTime.Now.AddMinutes(20),
        DateTime.Now.AddMinutes(25),
        DateTime.Now.AddMinutes(30),
        DateTime.Now.AddMinutes(35),
        DateTime.Now.AddMinutes(40),
        DateTime.Now.AddMinutes(45),
        DateTime.Now.AddMinutes(50),
        DateTime.Now.AddMinutes(55),
        DateTime.Now.AddMinutes(60),
        DateTime.Now.AddMinutes(65),
        DateTime.Now.AddMinutes(70),
        DateTime.Now.AddMinutes(75)
    };
    var result = foo.GroupBy(x => x.RoundUp(TimeSpan.FromMinutes(15))).Select(d =>  new { Date = d.Key, Dates = d.ToList()});
