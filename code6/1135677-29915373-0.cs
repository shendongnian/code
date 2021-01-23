    class Program
    {
        static void Main(string[] args)
        {
            if (ModifyExistingEntity(new Product { Name = "bar" }, new ProductModel { Name = "test" }))
                Console.WriteLine("Product modified");
            if (ModifyExistingEntity(new Customer { Number = 1001 }, new CustomerModel { Number = 1002 }))
                Console.WriteLine("Customer was modified");
            if (!ModifyExistingEntity(new Customer { Number = 1001 }, new CustomerModel { Number = 1001 }))
                Console.WriteLine("Customer was not modified");
            Console.ReadKey();
        }
        protected static bool ModifyExistingEntity<TEntity, TModel>(TEntity entity, TModel model)
        {
            return GetProperties(entity, model)
                .Any(
                    propertyInfo =>
                        !Equals(propertyInfo.Item1.GetValue(entity, null), propertyInfo.Item2.GetValue(model, null)));
        }
        private static readonly Dictionary<Tuple<Type, Type>, List<Tuple<PropertyInfo, PropertyInfo>>> Mapping =
                new Dictionary<Tuple<Type, Type>, List<Tuple<PropertyInfo, PropertyInfo>>>();
        protected static List<Tuple<PropertyInfo, PropertyInfo>> GetProperties<TEntity, TModel>(TEntity entity, TModel model)
        {
            var key = new Tuple<Type, Type>(typeof (TEntity), typeof (TModel));
            if (Mapping.ContainsKey(key))
            {
                return Mapping[key];
            }
            var modelProperties = typeof(TModel).GetProperties();
            var newMapping = (from propertyInfo in typeof (TEntity).GetProperties() 
                    let modelPropertyInfo = modelProperties.SingleOrDefault(mp => mp.Name == propertyInfo.Name) 
                    select new Tuple<PropertyInfo, PropertyInfo>(propertyInfo, modelPropertyInfo))
                    .ToList();
            Mapping.Add(key, newMapping);
            return newMapping;
        }
    }
