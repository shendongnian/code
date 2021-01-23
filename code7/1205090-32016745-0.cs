    var studentWithCountry = context.Student.Where(Id = myVar.Id)
       .Select(s => new { Level = s.Level,
                          Subject = s.Subject,
                          ...
                          Country = s.City.State.Country.Country });
