    public static class SchemaGetter
    {
        private static readonly Dictionary<object, Func<BaseSchema>> _lookup = new Dictionary<object, Func<BaseSchema>>();
        
        public static BaseSchema Get<T>()
        {
            Func<BaseSchema> action;
            
            if(!_lookup.TryGetValue(typeof(T), out action))
            {
                action = MakeDelegate<T>();
                
                _lookup.Add(typeof(T), action);
            }
            
            return action();            
        }
        
        private static Func<BaseSchema> MakeDelegate<T>()
        {
            // We did this before already...
            FieldInfo field = typeof(T).GetField("Schema", BindingFlags.Public | BindingFlags.Static);
            var fieldExpression = Expression.Field(null, field);
            
            var lambda = Expression.Lambda<Func<BaseSchema>>(fieldExpression);
            
            return lambda.Compile();
        }
    }
