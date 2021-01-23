    db.ReadonlyQuery<Transaction>()
                        .Select(t => new ACurrentDayInfo
                        {
                            OrderId = t.TransactionIdentifier,
                            OrderTime = t.TransactionTime,
                            UserInfo = t.UserInfo
                        }).ToListAsync();
