    var messages = msg.ToList();
    var results = messages.Where(x=> x.toUser = "aUserName" AND isDeleted="0")
        .GroupBy(x=>x.fromUser)
        .Select(x=>
         { 
             var maxitem = x.OrderByDescending(y=>y.ts).First();
             return new 
             {
                  fromUser = maxItem.fromUser,
                  ts = maxitem.ts,
                  ... // remaining properties.
             }
         })
        .ToList(); 
