    var x = db.Events
               .Where(ev=>ev.Id == 138)
               .SelectMany(ev=>ev.EventFacilities) //(i'm assumine possibly multiple and not 1 per event, once again schema doesn't show it, if it's not the case change SelectMany to Select)
               .SelectMany(ef=>ef.Assesments) // Same assumption as above
               .Select(as=>as.Assessor) // Asuming otherwise here, if wrong change Select to SelectMany
               .Distinct(); // Ignore duplicate assessors
