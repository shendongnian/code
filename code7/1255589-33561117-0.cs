    protected bool isPlayerdb(string userName)
    {
        try
        {
            return SoccerEntities
                .Users
                .Any(user => user.roleId == new Guid("ED85788D-72DA-4D0A-8D5E-B5378FC00592") 
                             && user.UserName == userName)
        }
        catch (Exception ex)
        {
            throw new EntityContextException("isPlayer failed.", ex);
        }
    }
