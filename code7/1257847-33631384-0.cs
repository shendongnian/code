    List<UserAlerts> userAlerts = await db.UserAlerts
                                          .Where(x => x.UserID == UserID)
                                          .ToListAsync()
                                          .Select(x => new UserAlerts
                                              {
                                                  Lat = x.Lat,
                                                  Lon = x.Lon,
                                                  TimeTriggered = x.TimeTriggered,
                                                  TimeEnded = x.TimeEnded,
                                                  UserID = x.UserID
                                              })
                                          .ToListAsync();;
