        [ConfigurationElementType(typeof(CustomMatchingRuleData))]
        public class InstanceOfMatchingRule : IMatchingRule
        {
            private readonly Type _type;
            public InstanceOfMatchingRule(NameValueCollection configuration)
            {
                _type = Type.GetType(configuration["type"]);
            }
            public InstanceOfMatchingRule(Type type)
            {
                _type = type;
            }
            public bool Matches(System.Reflection.MethodBase member)
            {
                return _type.IsAssignableFrom(member.DeclaringType);
            }
        }
