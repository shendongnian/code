    [DirectoryRdnPrefix("CN")]
    [DirectoryObjectClass("Person")]
    public class UserPrincipalEXT : UserPrincipal
    {
        // Inplement the constructor using the base class constructor. 
        public UserPrincipalEXT(PrincipalContext context)
            : base(context)
        { }
        // Implement the constructor with initialization parameters.    
        public UserPrincipalEXT(PrincipalContext context,
                             string samAccountName,
                             string password,
                             bool enabled)
            : base(context, samAccountName, password, enabled)
        { }
        // Create the "employeeType" property with the "!" for NOT LIKE.    
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
        // Implement the overloaded search method FindByIdentity.
        public static new UserPrincipalEXT FindByIdentity(PrincipalContext context, string identityValue)
        {
            return (UserPrincipalEXT)FindByIdentityWithType(context, typeof(UserPrincipalEXT), identityValue);
        }
        // Implement the overloaded search method FindByIdentity. 
        public static new UserPrincipalEXT FindByIdentity(PrincipalContext context, IdentityType identityType, string identityValue)
        {
            return (UserPrincipalEXT)FindByIdentityWithType(context, typeof(UserPrincipalEXT), identityType, identityValue);
        }
    }
