        private class SearchFilter<T>
        {
            public Expression<Func<object, bool>> ApplySearchCondition { get; set; }
            public Expression<Func<T, bool>> SearchExpression { get; set; }
            public object SearchValue { get; set; }
            public IQueryable<T> Apply(IQueryable<T> query)
            {
                //if the search value meets the criteria (e.g. is not null), apply it; otherwise, just return the original query.
                bool valid = ApplySearchCondition.Compile().Invoke(SearchValue);
                return valid ? query.Where(SearchExpression) : query;
            }
        }
