    var result = (from x in _baseCommands.GetAll<UserActivity>()
                  group x by new { x.LoginDateTime, x.Culture} into g
                  select new UserActivityResponseContract
                  { 
                     ActivityDate = g.Key.LoginDateTime.ToShortDateString(),
                     Culture = g.Key.Culture, 
                     NumberOfTimesLoggedIn = g.Count()
                  }).Take(1000).ToList();
