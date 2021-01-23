    public void GetCMemberDisplayName()
    {
        var c = new C
        {
            M1 = new List<string> {"a"},
        };
    
        var m1MemberInfo = GetMemberInfo(() => c.M1);
        var nameOfM1 = GetDisplayName(m1MemberInfo);
    }
    private string GetDisplayName(MemberInfo memberInfo)
    {
    	var displayNameAttribute = memberInfo.GetCustomAttribute(typeof(DisplayNameAttribute));
    
    	if (displayNameAttribute != null)
    	{
    		return displayNameAttribute.DisplayName;
    	}
    	else
    	{
    		throw new Exception("No DisplayNameAttributes Applied.");
    	}
    }
