    public void GetCMemberDisplayName()
        {
            var c = new C
            {
                M1 = new List<string> {"a"},
            };
        
            var nameOfM1 = GetDisplayName(typeof(C), nameof(c.M1));
        }
    
    
    private static string GetDisplayName(Type ownerType, string propertyName)
    {
    	var propertyInfo = ownerType.GetProperty(propertyName);
    
    	var displayNameAttribute = propertyInfo.GetCustomAttribute(typeof(DisplayNameAttribute));
    
    	if (displayNameAttribute != null)
    	{
    		return displayNameAttribute.DisplayName;
    	}
    	else
    	{
    		throw new Exception("No DisplayNameAttributes Applied.");
    	}
    }
