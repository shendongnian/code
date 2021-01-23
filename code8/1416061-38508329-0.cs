        public IQueryable<T> Apply<T>( IQueryable<T> source, Expression<Func<T,DateTime>> dateField )
        {
            Expression predicate;
            if (BeginDate.HasValue)
            {
                if (BeginInclusive)
                    predicate = Expression.GreaterThanOrEqual( dateField.Body, Expression.Constant( BeginDate, typeof(DateTime) ) );
                else
                    predicate = Expression.GreaterThan( dateField.Body, Expression.Constant( BeginDate, typeof(DateTime) ) );
                source = source.Where( Expression.Lambda<Func<T, bool>>( predicate ) );
            }
            if (EndDate.HasValue)
            {
                if (EndInclusive)
                    predicate = Expression.LessThanOrEqual( dateField.Body, Expression.Constant( EndDate, typeof(DateTime) ) );
                else
                    predicate = Expression.LessThan( dateField.Body, Expression.Constant( EndDate, typeof(DateTime) ) );
                source = source.Where( Expression.Lambda<Func<T, bool>>( predicate ) );
            }
            return source;
        }
