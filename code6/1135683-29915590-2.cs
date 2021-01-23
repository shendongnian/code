    public class Modifier
    {
        public Entity E { get; private set; }
    
        public bool IsModified { get; private set; }
    
        public Modifier(Entity e)
        {
            E = e;
        }
    
        public void Update<TProperty>(Expression<Func<Entity, TProperty>> entityPropertyGetter, TProperty modelValue)
        {
            var newValue = Expression.Parameter(entityPropertyGetter.Body.Type);
    
            var assign = Expression.Lambda<Action<Entity, TProperty>>(
                Expression.Assign(entityPropertyGetter.Body, newValue),
                expr.Parameters[0], newValue);
    
            var getter = entityPropertyGetter.Compile();
            var setter = assign.Compile();
    
            if (!object.Equals(getter(E), modelValue))
            {
                IsModified = true;
                setter(E, modelValue);
            }
        }
    }
