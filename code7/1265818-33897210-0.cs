    public class UserRoleConverter : ITypeConverter<UserRole, string>
    {
        public string Convert(ResolutionContext context)
        {
             // Assuming a "Name" property on UserRole
             return ((UserRole)context.SourceValue).Name;
    	}
    } 
