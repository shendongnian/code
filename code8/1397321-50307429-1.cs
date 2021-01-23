        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);
            if (member.GetCustomAttribute<JsonPropertyNameBasedOnItemClassAttribute>() != null)
            {
                Type[] arguments = property.DeclaringType.GenericTypeArguments;
                if(arguments.Length > 0)
                {
                    string name = arguments[0].Name.ToString();
                    property.PropertyName = name.ToLower().Pluralize();
                }
                return property;
            }
            return base.CreateProperty(member, memberSerialization);
        }
