    public class EntityByCustomSpecification<TEntity> : Specification<TEntity> where TEntity : class, new()
    {
        Expression<Func<TEntity, bool>> _Expression = null;
        public EntityByCustomSpecification(Expression<Func<TEntity, bool>> expression)
        {
            this._Expression = expression;
        }
        public override Expression<Func<TEntity, bool>> SatisfiedBy()
        {
            return this._Expression;
        }
    }
