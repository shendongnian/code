    public class KeyedBaseModel<TEntity, TKey>
    {
        public static readonly Type EntityType = typeof(TEntity);
        public static readonly Type KeyType = typeof(TKey);
        public static readonly PropertyInfo KeyProperty = EntityType.GetProperty(nameof(Id), BindingFlags.Public | BindingFlags.Instance);
        
        public static Expression<Func<TEntity, bool>> IdEquals(TKey key)
        {
            var parameter = Expression.Parameter(EntityType, "x"); // x => 
            var property = Expression.Property(parameter, KeyProperty); // x => x.Id
            var constant = Expression.Constant(key, KeyType); // id
            var equal = Expression.Equal(property, constant); // x => x.Id == id
            
            return Expression.Lambda<Func<TEntity, bool>>(equal, parameter);
        }      
        
        public TKey Id { get; protected set; }
    }
