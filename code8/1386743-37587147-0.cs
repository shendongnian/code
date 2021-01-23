    var listData = db.ReadonlyQuery<Transaction>()
                            .Select(t => new ACurrentDayInfo
                            {
                                OrderId = t.TransactionIdentifier,
                                OrderTime = t.TransactionTime,
    
                                UserInfo = t.UserInfo
                            }).ToListAsync();
    
    foreach (var item in listData)
    {
        item.UserName = JsonConvert.DeserializeObject<UserInfo>(t.UserInfo).RealName ?? "" 
    }
