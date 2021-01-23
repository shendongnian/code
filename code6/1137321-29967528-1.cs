    var particips = from p in db.Participants 
                    join m in db.Medals on p.MedalID equals m.ID 
                    select new { p.FirstName, m.Name, p.Event };
    foreach (var particip in particips)
    {
        Console.WriteLine(
                "{0} won a {1} medal in \"{2}\"", 
                particip.FirstName, 
                particip.Name, 
                particip.Event);
    }
