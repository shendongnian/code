    public class JsonNameBasedOnItemClassNameAttribute : Attribute {}
    public class CustomResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty prop = base.CreateProperty(member, memberSerialization);
            if (prop.PropertyType.IsGenericType && member.GetCustomAttribute<JsonNameBasedOnItemClassNameAttribute>() != null)
            {
                prop.PropertyName = Pluralize(prop.PropertyType.GetGenericArguments().First().Name.ToLower());
            }
            return prop;
        }
        protected string Pluralize(string name)
        {
            if (name.EndsWith("y") && !name.EndsWith("ay") && !name.EndsWith("ey") && !name.EndsWith("oy") && !name.EndsWith("uy"))
                return name.Substring(0, name.Length - 1) + "ies";
            if (name.EndsWith("s"))
                return name + "es";
            return name + "s";
        }
    }
