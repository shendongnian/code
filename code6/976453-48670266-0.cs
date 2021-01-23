    public new static User FindByIdentity(PrincipalContext context, string identityValue)
    {
    	return (User)FindByIdentityWithType(context, typeof(User), identityValue);
    }
    
    public new static User FindByIdentity(PrincipalContext context, IdentityType identityType, string identityValue)
    {
    	return (User)FindByIdentityWithType(context, typeof(User), identityType, identityValue);
    }
