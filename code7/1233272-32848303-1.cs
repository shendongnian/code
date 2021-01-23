    public static class People
    {
        static Dictionary<PersonType, Type> mapping = new Dictionary<PersonType, Type>();
        static People()
        {
            var fields = Enum.GetNames(typeof(PersonType)).Select(n => typeof(PersonType).GetFieldr(n));
            mapping = fields.ToDictionary(
                f => (PersonType)f.GetRawConstantValue(),
                f => f.GetCustomAttribute<PersonClassAttribute>().Type
                );
        }
        public static T GetPersonInstance<T>(this PersonType type)
        {
           return (T)Activator.CreateInstance(mapping[type]);
        }
    }
