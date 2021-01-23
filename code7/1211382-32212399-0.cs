    public class MongoMappingConvention : IClassMapConvention
        {
            public string Name
            {
                get { return "No use for a name"; }
            }
            public void Apply(BsonClassMap classMap)
            {
                var nonPublicCtors = classMap.ClassType.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance);
                var longestCtor = nonPublicCtors.OrderByDescending(ctor => ctor.GetParameters().Length).FirstOrDefault();
                classMap.MapConstructor(longestCtor);
                var publicProperties = classMap.ClassType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.CanRead);
                foreach (var publicProperty in publicProperties)
                {
                    classMap.MapMember(publicProperty);
                }
            }
        }
