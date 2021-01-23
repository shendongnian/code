    public class EverythingButBaseContractResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            if (member.ReflectedType != member.DeclaringType)
                return null;
            if (member is PropertyInfo)
            {
                var getMethod = ((PropertyInfo)member).GetGetMethod(false);
                if (getMethod.GetBaseDefinition() != getMethod)
                    return null;
            }
            var property = base.CreateProperty(member, memberSerialization);
            return property;
        }
    }
