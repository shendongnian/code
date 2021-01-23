    public virtual ObjectLockInfo Lock(int id)
    {
        using (var context = DataContextFactory.GetContext())
        using (var dbContextTransaction = context.Database.BeginTransaction(IsolationLevel.Serializable)) 
        {                
             var i =
                context.ObjectLock.Any(
                    c =>
                        c.ObjectID == id && (c.ObjectType == (int) _lockObjectType) &&
                        c.LockExpireDate > DateTime.Now);
            if (i)
                return new ObjectLockInfo
                {
                    ErrorMessage = "Object is locked",
                    IsLocked = false
                };
            var lockLock = new ObjectLock
            {
                LockExpireDate = DateTime.Now.AddMinutes(20),
                LockObjectDate = DateTime.Now,
                ObjectID = id,
                ObjectType = (int) _lockObjectType,
                UserID = _currentUserID
            };
            context.ObjectLock.Add(lockLock);
            context.SaveChanges();
            dbContextTransaction.Commit();
            return new ObjectLockInfo
            {
                Id = lockLock.ID,
                IsLocked = true,
                LockDate = lockLock.LockObjectDate,
                LockExpireDate = lockLock.LockExpireDate
            };
        }
    }
