       public virtual T GetSingle(Expression<Func<T, bool>> predicate)
        {
            if (predicate != null)
            {
                return context.Set<T>().Where(predicate).SingleOrDefault();
            }
            else
            {
                throw new ArgumentNullException("Predicate value is null");
            }
        }
