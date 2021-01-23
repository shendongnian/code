    void Main()
    {	
    	CustomFields value1 = GetEnumValue("first_name");
    	CustomFields value2 = GetEnumValue("last_name");
    }
    
    static Dictionary<string, CustomFields> displayNameMapping;
    
    static CustomFields GetEnumValue(String displayName){
    	if (displayNameMapping == null){
    		var enumType = typeof(CustomFields);
    		var displayAttributeType = typeof(DisplayAttribute);
    		CustomFields? found = null;
    		
    		displayNameMapping = new Dictionary<string, CustomFields>();
    		Enum.GetNames(enumType).ToList().ForEach(name=>{
    			var member = enumType.GetMember(name).First();
    			var displayAttrib = (DisplayAttribute)member.GetCustomAttributes(displayAttributeType, false).First();
    			displayNameMapping.Add(displayAttrib.Name, (CustomFields)Enum.Parse(enumType, name));
    		});
    	}
    	
    	return displayNameMapping[displayName];
    }
    
    // Define other methods and classes here
    public enum CustomFields
    {
        [Display(Name = "first_name")]
        FirstName = 1,
    
        [Display(Name = "last_name")]
        LastName = 2,
    }
