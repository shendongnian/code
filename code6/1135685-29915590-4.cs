    public class Modifier<TEntity>
    {    
        public Modifier(TEntity e)
        {
            Entity = e;
        }
        public TEntity Entity { get; private set; }
    
        public bool IsModified { get; private set; }
    
        public void Update<TProperty>(Expression<Func<TEntity, TProperty>> entityPropertyGetter, TProperty modelValue)
        {
            var newValue = Expression.Parameter(entityPropertyGetter.Body.Type);
    
            var assign = Expression.Lambda<Action<TEntity, TProperty>>(
                Expression.Assign(entityPropertyGetter.Body, newValue),
                expr.Parameters[0], newValue);
    
            var getter = entityPropertyGetter.Compile();
            var setter = assign.Compile();
    
            if (!object.Equals(getter(Entity), modelValue))
            {
                IsModified = true;
                setter(Entity, modelValue);
            }
        }
    }
