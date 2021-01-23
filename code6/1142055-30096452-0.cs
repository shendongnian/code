    class Program
    {
        static void Main(string[] args)
        {
            PropertyInfo[] result = GetAllPropertyInfos(typeof(Example)).ToArray(); ;
            foreach (string property in result.Select(p => string.Format("{0} : {1}",p.Name,p.PropertyType.Name)))
            {
                Console.WriteLine(property);
            }
        }
        static IEnumerable<PropertyInfo> GetAllPropertyInfos(Type type)
        {
            List<PropertyInfo> result = new List<PropertyInfo>();
            foreach (PropertyInfo propertyInfo in type.GetProperties())
            {
                result.Add(propertyInfo);
                result.AddRange(GetAllPropertyInfos(propertyInfo.PropertyType));
            }
            return result;
        }
    }
    class Example
    {
        public AnotherExample AProperty { get; set; }
        public int AnotherProperty { get; set; }
    }
    class AnotherExample
    {
        public int YetAnotherProperty { get; set; }
    }
