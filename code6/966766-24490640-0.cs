    using (var redisclient = RedisManager.GetClient())
    {
        var redisUser = redisclient.As<RequestCall>();
        if (erisim == "A")
        {
            return redisUser.GetAll();// .Where(c=>c.Sube=="Y");
        }
        else if (erisim == "P")
        {
            return redisUser.GetAll().Where(c => c.Sube == sube);
        }
        else if (erisim == "C")
        {
            return redisUser.GetAll().Where(c => c.CagriAcan == sicil);
        }
        else return null;
    }
