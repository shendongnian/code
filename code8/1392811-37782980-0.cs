        public static class CustomAttrr
    {
        public static IEnumerable<ActionsWithAuthActivityAttribute> GetItems(Assembly types)
        {
            var model = from type in types.GetTypes()
                        from methodInfo in type.GetMethods().Where(x => x.GetCustomAttributes<AuthActivityAttribute>().Any())
                        from attribute in methodInfo.GetCustomAttributes()
                        where attribute is AuthActivityAttribute
                        let a = attribute as AuthActivityAttribute
                        select new ActionsWithAuthActivityAttribute
                        {
                            ActionName = methodInfo.Name,
                            ActivityName = a.ActivityName,
                        };
            return model.ToList();
        }
    }
    public class AuthActivityAttribute:Attribute
    {
        public string ActivityName { get; set; }
    }
    public class ActionsWithAuthActivityAttribute
    {
        public string ActionName { get; set; }
        public string ActivityName { get; set; }
    }
