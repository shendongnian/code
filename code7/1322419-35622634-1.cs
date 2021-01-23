    var result = db.TransactionLogs
                   .GroupBy(x => new 
                                { 
                                   CreateTime = EntityFunctions.TruncateTime(x.CreatedTime),
                                   UserId,
                                   CompanyId 
                                })
                   .Select(x => new
                               {
                                    UserId = x.Key.UserId,
                                    CompanyId = x.Key.CompanyId,
                                    CreateTime = x.Key.CreateTime,
                                    TotalTimeSpentMins = x.Sum(z => z.TimeSpentMins)
                               });
