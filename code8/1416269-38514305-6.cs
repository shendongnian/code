    private dynamic ParseDateOfBirth(string info)
    {
            return info.Split(';')
               .Select(n => n.Split(','))
               .Select(n => new { 
                         name = n[0].Trim(), 
                         datetime = DateTime.ParseExact(n[1].Trim(), 
                                                        "d/M/yyyy",
                                                         CultureInfo.InvariantCulture) });
     }
