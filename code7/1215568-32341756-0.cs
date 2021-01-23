    public class ExpressionHelper : ExpressionVisitor
    {
        private MemberExpression m_MemberExpression;
        public MemberExpression GetPropertyAccessExpression(Expression expression)
        {
            m_MemberExpression = null;
            Visit(expression);
            return m_MemberExpression;
        }
        protected override Expression VisitMember(MemberExpression node)
        {
            var property = node.Member as PropertyInfo;
            if (property != null)
            {
                m_MemberExpression = node;
            }
            return base.VisitMember(node);
        }
    }
    public class DataClass<TEntity>
    {
        private readonly IQueryable<TEntity> m_Queryable;
        public DataClass(IQueryable<TEntity> queryable)
        {
            m_Queryable = queryable;
        }
        public virtual IEnumerable<TEntity> GetSorted(
            Expression<Func<TEntity, object>> order,
            int skip, int take,
            params Expression<Func<TEntity, object>>[] includes)
        {
            var property_access_expression = new ExpressionHelper().GetPropertyAccessExpression(order);
            if(property_access_expression == null)
                throw new Exception("Expression is not a property access expression");
            var property_info = (PropertyInfo) property_access_expression.Member;
            var covert_method = this.GetType().GetMethod("Convert").MakeGenericMethod(property_info.PropertyType);
            var new_expression = covert_method.Invoke(this, new object[] {property_access_expression, order.Parameters });
            var get_sorted_method = this.GetType()
                .GetMethod("GetSortedSpecific")
                .MakeGenericMethod(property_info.PropertyType);
            return (IEnumerable<TEntity>)get_sorted_method.Invoke(this, new object[] { new_expression, skip, take, includes });
        }
        public virtual IEnumerable<TEntity> GetSortedSpecific<TSortedBy>(
            Expression<Func<TEntity, TSortedBy>> order,
            int skip, int take,
            params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = m_Queryable;
            //Here do your include logic and any other logic
            IEnumerable<TEntity> data = query.OrderBy(order).Skip(skip).Take(take).ToList();
            return data;
        }
        public Expression<Func<TEntity, TNewKey>> Convert<TNewKey>(
            MemberExpression expression, ReadOnlyCollection<ParameterExpression> parameter_expressions )
        {
            return Expression.Lambda<Func<TEntity, TNewKey>>(expression, parameter_expressions);
        }
    }
