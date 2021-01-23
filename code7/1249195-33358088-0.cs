    public class SkipNullResolverStrategy : PocoResolverStrategy
    {
        public override ValueIgnoredDelegate GetValueIgnoredCallback(MemberInfo member)
        {
            Type type;
            if (member is PropertyInfo)
                type = ((PropertyInfo)member).PropertyType;
            else if (member is FieldInfo)
                type = ((FieldInfo)member).FieldType;
            else
                type = null;
            var baseValueIgnored = base.GetValueIgnoredCallback(member);
            if (type != null && (!type.IsValueType || Nullable.GetUnderlyingType(type) != null))
            {
                return (ValueIgnoredDelegate)((instance, memberValue) => (memberValue == null || (baseValueIgnored != null && baseValueIgnored(instance, memberValue))));
            }
            else
            {
                return baseValueIgnored;
            }
        }
    }
