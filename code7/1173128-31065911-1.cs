        public LinqDynamicConverter<TInput,TOutput> Select<TProperty,TConverted>(
            Expression<Func<TOutput, TConverted>> initializedOutputProperty,
            Expression<Func<TInput, TProperty>> subPath,
            Expression<Func<TProperty, TConverted>> subSelect)
        {
            LinqRebindVisitor<TConverted, TProperty> rebindVisitor = new LinqRebindVisitor<TConverted, TProperty>(subPath);
            rebindVisitor.Visit(subSelect);
            var result = rebindVisitor.ResultExpression;
            return Property<TConverted>(initializedOutputProperty, result);
        }
