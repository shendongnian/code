    public class UndiscriminatedActualTypeConvention : ConventionBase, IClassMapConvention
    {
        public void Apply(BsonClassMap cm)
        {
            Type type = cm.ClassType;
            if (type.IsClass
                && type != typeof(string)
                && type != typeof(object)
                && !type.IsAbstract)
            {
                foreach (var memberMap in cm.DeclaredMemberMaps)
                {
                    var genericBase = typeof(UndiscriminatedActualTypeSerializer<>);
                    var genericType = genericBase.MakeGenericType(new[] { memberMap.MemberType });
                    var serializer = genericType
                        .GetProperty("Instance", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static)
                        .GetValue(null, null) as IBsonSerializer;
                    cm.MapMember(memberMap.MemberInfo).SetSerializer(serializer);
                }
            }
        }
    }
