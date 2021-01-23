    // Create the "employeeType" property.    
    [DirectoryProperty("!employeeType")]
    public string NotLikeEmployeeType
    {
        get
        {
            if (ExtensionGet("!employeeType").Length != 1)
                    return string.Empty;
            return (string)ExtensionGet("!employeeType")[0];
         }
         set { ExtensionSet("!employeeType", value); }
    }
