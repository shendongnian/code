    var result = _baseCommands.GetAll<UserActivity>()
                              .GroupBy(x => new { x.LoginDateTime, x.Culture})
                              .Select (x => new UserActivityResponseContract
                              { 
                                  ActivityDate = x.Key.LoginDateTime.ToShortDateString(),
                                  Culture = x.Key.Culture, 
                                  NumberOfTimesLoggedIn = x.Count()
                              })
                              .Take(1000).ToList(); 
