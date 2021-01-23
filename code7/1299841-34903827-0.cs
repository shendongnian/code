    public class IgnoreEmptyEnumerablesResolver : DefaultContractResolver
    {
        public new static readonly IgnoreEmptyEnumerablesResolver Instance = new IgnoreEmptyEnumerablesResolver();
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);
            if (property.DeclaringType is IEnumerable)
            {
                property.ShouldSerialize = instance =>
                {
                    var enumer = instance
                        .GetType()
                        .GetProperty(property.PropertyName)
                        .GetValue(instance, null) as IEnumerable;
                    if (enumer != null)
                    {
                        // check to see if there is at least one item in the Enumerable
                        return enumer.GetEnumerator().MoveNext();
                    }
                    else
                    {
                        // if the enumerable is null, we defer the decision to NullValueHandling
                        return true;
                    }
                    
                };
            }
            return property;
        }
    }
