    public class IgnoreEmptyEnumerablesResolver : DefaultContractResolver
    {
        public new static readonly IgnoreEmptyEnumerablesResolver Instance = new IgnoreEmptyEnumerablesResolver();
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);
            
            if (property.PropertyType != typeof(string) &&
                typeof(IEnumerable).IsAssignableFrom(property.PropertyType))
            {
                property.ShouldSerialize = instance =>
                {
                    IEnumerable enumerable = null;
                    // this value could be in a public field or public property
                    switch (member.MemberType)
                    {
                        case MemberTypes.Property:
                            enumerable = instance
                                .GetType()
                                .GetProperty(member.Name)
                                .GetValue(instance, null) as IEnumerable;
                            break;
                        case MemberTypes.Field:
                            enumerable = instance
                                .GetType()
                                .GetField(member.Name)
                                .GetValue(instance) as IEnumerable;
                            break;
                        default:
                            break;
                    }
                    if (enumerable != null)
                    {
                        // check to see if there is at least one item in the Enumerable
                        return enumerable.GetEnumerator().MoveNext();
                    }
                    else
                    {
                        // if the list is null, we defer the decision to NullValueHandling
                        return true;
                    }
                };
            }
            return property;
        }
    }
