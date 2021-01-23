    var emailActivityList = serviceContext.CreateQuery<Email>()
                .Where(x => x.RegardingObjectId.Id == accountId).ToList();
    var taskActivityList = serviceContext.CreateQuery<Task>()
                .Where(x => x.RegardingObjectId.Id == accountId).ToList();
    //and so on
