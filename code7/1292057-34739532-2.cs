    userId = signedInUserId;
	this.AfterAccess = AfterAccessNotification;
	this.BeforeAccess = BeforeAccessNotification;
	this.BeforeWrite = BeforeWriteNotification;
	// look up the entry in the database
	Cache = db.UserTokenCacheList.FirstOrDefault(c => c.webUserUniqueId == userId);
	// place the entry in memory
	this.Deserialize((Cache == null) ? null : MachineKey.Unprotect(Cache.cacheBits,"ADALCache"));
