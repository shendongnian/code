    [ConfigurationProperty("Prompt")]
    public string Prompt
    {
    	get { return this.GetNullableStringValue("Prompt"); }
    }
    
    private string GetNullableStringValue(string propertyName)
    {
    	return (string)this[new ConfigurationProperty(propertyName, typeof(string), null)];
    }
