    public class Modifier<TEntity>
    {    
        public Modifier(TEntity entity)
        {
            Entity = entity;
        }
        public TEntity Entity { get; private set; }
    
        public bool EntityWasModified { get; private set; }
        public Modifier<TEntity> UpdateIfNeeded<TProperty>(Expression<Func<TEntity, TProperty>> entityPropertyGetter, TProperty modelValue)
        {
            var getter = entityPropertyGetter.Compile();
            var setter = GetSetterExpression(entityPropertyGetter).Compile();
    
            if (!object.Equals(getter(Entity), modelValue))
            {
                setter(Entity, modelValue);
                EntityWasModified = true;
            }
            return this;
        }
    
        private static Expression<Action<TEntity, TProperty>> GetSetterExpression(Expression<Func<TEntity, TProperty>> getterExpression)
        {
            var newValue = Expression.Parameter(getterExpression.Body.Type);
    
            return Expression.Lambda<Action<TEntity, TProperty>>(
                Expression.Assign(getterExpression.Body, newValue),
                getterExpression.Parameters[0], newValue);
        }
    }
