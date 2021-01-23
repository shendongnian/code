    public string DeserializeNavigationProperty(NavigationProperty navigationProperty)
    {
    	string navPropCode = NavigationProperty(navigationProperty);
    	navPropCode = navPropCode.Replace("ICollection","List");
    	return navPropCode;
    }
