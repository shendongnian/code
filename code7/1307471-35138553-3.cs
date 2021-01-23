    private class MyContractResolver : DefaultContractResolver
	{
	  private Dictionary<string,string> _translate;
	  public MyContractResolver(Dictionary<string, string> translate)
	  {
	    _translate = translate;
	  }
	  protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
	  {
		var property = base.CreateProperty(member, memberSerialization);
		string newPropertyName;
		if(_translate.TryGetValue(property.PropertyName, out newPropertyName))
	      property.PropertyName = newPropertyName;
		return property;
	  }
	}
