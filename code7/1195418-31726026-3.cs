        [ConfigurationElementType(typeof(CustomMatchingRuleData))]
        public class InstanceOfMatchingRule : IMatchingRule
        {
            private readonly Type _type;
            public InstanceOfMatchingRule(NameValueCollection configuration)
            {
                _type = Type.GetType(configuration["targetType"]);
            }
            public InstanceOfMatchingRule(Type targetType)
            {
                _type = targetType;
            }
            public bool Matches(System.Reflection.MethodBase member)
            {
                return _type.IsAssignableFrom(member.DeclaringType);
            }
        }
