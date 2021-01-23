        [System.AttributeUsage(System.AttributeTargets.Property | System.AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
        public class LegacyDataMemberNamesAttribute : Attribute {
            public readonly string[] LegacyNames;
            public LegacyDataMemberNamesAttribute(params string[] legacyNames) {
                LegacyNames = legacyNames;
            }
        }
        public class LegacyPropertyResolver : DefaultContractResolver {
            // As of 7.0.1, Json.NET suggests using a static instance for "stateless" contract resolvers, for performance reasons.
            // http://www.newtonsoft.com/json/help/html/ContractResolver.htm
            // http://www.newtonsoft.com/json/help/html/M_Newtonsoft_Json_Serialization_DefaultContractResolver__ctor_1.htm
            // "Use the parameterless constructor and cache instances of the contract resolver within your application for optimal performance."
            public static readonly LegacyPropertyResolver Instance = new LegacyPropertyResolver();
            protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization) {
                var properties = base.CreateProperties(type, memberSerialization);
                foreach (var property in properties.ToArray()) {
                    if (!property.Writable) continue;
                    foreach (var legacyName in GetLegacyNames(property)) {
                        properties.Add(CloneWithLegacyName(property, legacyName));
                    }
                }
                return properties;
            }
            static IEnumerable<string> GetLegacyNames(JsonProperty property) {
                return property.AttributeProvider.GetAttributes(typeof(LegacyDataMemberNamesAttribute), true)
                        .Cast<LegacyDataMemberNamesAttribute>()
                        .SelectMany(a => a.LegacyNames)
                        .Distinct();
            }
            static readonly object[] _emptyObjectArray = new object[0];
            static readonly MethodInfo _propertyClone = typeof(JsonProperty).GetMethod("MemberwiseClone", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            static JsonProperty CloneWithLegacyName(JsonProperty property, string legacyName) {
                var legacyProperty = (JsonProperty)_propertyClone.Invoke(property, _emptyObjectArray);
                legacyProperty.Readable = false;
                legacyProperty.PropertyName = legacyName;
                return legacyProperty;
            }
        }
