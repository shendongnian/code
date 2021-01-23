        public static IQueryable<T> WhereValueIn<T>(this IQueryable<T> query,
            Expression<Func<T, long>> propertyAccessor, ICollection<long> valuesList)
        {
            return query.Where(PrepareContainsPredicate(propertyAccessor, valuesList));
        }
        private static Expression<Func<T1, T3>> Combine<T1, T2, T3>(
            Expression<Func<T1, T2>> first,
            Expression<Func<T2, T3>> second)
        {
            var param = Expression.Parameter(typeof(T1), @"param");
            var newFirst = new ReplaceVisitor(first.Parameters.First(), param).Visit(first.Body);
            var newSecond = new ReplaceVisitor(second.Parameters.First(), newFirst).Visit(second.Body);
            return Expression.Lambda<Func<T1, T3>>(newSecond, param);
        }
        public static Expression<Func<T, bool>> PrepareContainsPredicate<T>(Expression<Func<T, long>> idAccessor, ICollection<long> entityIds)
        {
            if (entityIds.Count == 1)
            {
                var cardId = entityIds.First();
                return Combine(idAccessor, x => x == cardId);
            }
            if (entityIds.Count == 2)
            {
                var card1Id = entityIds.ElementAt(0);
                var card2Id = entityIds.ElementAt(1);
                return Combine(idAccessor, x => x == card1Id || x == card2Id);
            }
            if (entityIds.Count == 3)
            {
                var card1Id = entityIds.ElementAt(0);
                var card2Id = entityIds.ElementAt(1);
                var card3Id = entityIds.ElementAt(2);
                return Combine(idAccessor, x => x == card1Id || x == card2Id || x == card3Id);
            }
            return Combine(idAccessor, x => entityIds.Contains(x));
        }
        private sealed class ReplaceVisitor : ExpressionVisitor
        {
            private readonly Expression _from;
            private readonly Expression _to;
            public ReplaceVisitor(Expression from, Expression to)
            {
                _from = from;
                _to = to;
            }
            public override Expression Visit(Expression node)
            {
                return node == _from ? _to : base.Visit(node);
            }
        }
