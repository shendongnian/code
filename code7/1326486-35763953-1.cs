    //will be XXXXXXXXXXXXXXX
    var cache = Container.Resolve<ICacheClient>();
    var sessionPattern = IdUtils.CreateUrn<IAuthSession>("");
    var sessionKeys = cache.GetKeysStartingWith(sessionPattern).ToList();
    var allSessions = cache.GetAll<IAuthSession>(sessionKeys);
    var cacheSes = allSessions.FirstOrDefault().Key;
