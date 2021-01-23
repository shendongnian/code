    public static class MemberInfoExtensions
    {
        public static bool IsAttributeDefined<TAttribute>(this MemberInfo memberInfo)
        {
            return memberInfo.IsAttributeDefined(typeof(TAttribute));
        }
    
        public static bool IsAttributeDefined(this MemberInfo memberInfo, Type attributeType)
        {
            return memberInfo.GetCustomAttribute(attributeType) != null;
        }
    }
