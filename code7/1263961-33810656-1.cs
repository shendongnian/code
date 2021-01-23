        private static void SeedEntity<TEntity>(DbContext context, ref TEntity entity, params Expression<Func<TEntity, object>>[] identifierExpressions) 
            where TEntity : class
        {
            Expression<Func<TEntity, bool>> allExpresions = null;
            foreach (Expression<Func<TEntity, object>> identifierExpression in identifierExpressions)
            {
                Func<TEntity, object> vv = identifierExpression.Compile();
                object constant = vv(entity);
                ConstantExpression constExp = Expression.Constant(constant, typeof(object));
                BinaryExpression equalExpression1 = Expression.Equal(identifierExpression.Body, constExp);
                Expression<Func<TEntity, bool>> equalExpression2 = Expression.Lambda<Func<TEntity, bool>>(equalExpression1, identifierExpression.Parameters);
                if (allExpresions == null)
                {
                    allExpresions = equalExpression2;
                }
                else
                {
                    var visitor = new ExpressionSubstitute(allExpresions.Parameters[0], identifierExpression.Parameters[0]);
                    var modifiedAll = (Expression<Func<TEntity,bool>>)visitor.Visit(allExpresions);
                    BinaryExpression bin = Expression.And(modifiedAll.Body, equalExpression2.Body);
                    allExpresions = Expression.Lambda<Func<TEntity, bool>>(bin, identifierExpression.Parameters);
                }
            }
            TEntity existingEntity = null;
            if (allExpresions != null)
            {
                existingEntity = context.Set<TEntity>().FirstOrDefault(allExpresions);
            }
            if (existingEntity == null)
            {
                context.Set<TEntity>().Add(entity);
            }
            else
            {
                entity = existingEntity;
            }
        }
