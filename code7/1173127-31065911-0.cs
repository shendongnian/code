        /// <summary>
        /// rebinds a full expression tree to a new single property
        /// Example: we get x => x.Sub as subPath. Now the visitor starts visiting a new
        /// expression x => x.Text. The result should be x => x.Sub.Text.
        /// Traversing member accesses always starts with the rightmost side working toward the parameterexpression.
        /// So when we reach the parameterexpression we have to inject the whole subpath including the parameter of the subpath
        /// </summary>
        /// <typeparam name="TConverted"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        private class LinqRebindVisitor<TConverted, TProperty> : ExpressionVisitor
        {
            public Expression<Func<TInput, TConverted>> ResultExpression { get; private set; }
            private ParameterExpression SubPathParameter { get; set; }
            private Expression SubPathBody { get; set; }
            private bool InitialMode { get; set; }
            public LinqRebindVisitor(Expression<Func<TInput, TProperty>> subPath)
            {
                SubPathParameter = subPath.Parameters[0];
                SubPathBody = subPath.Body;
                InitialMode = true;
            }
            
            protected override Expression VisitMember(MemberExpression node)
            {
                // Note that we cannot overwrite visitparameter because that method must return a parameterexpression
                // So whenever we detect that our next expression will be a parameterexpression, we inject the subtree
                if (node.Expression is ParameterExpression && node.Expression != SubPathParameter)
                {
                    var expr = Visit(SubPathBody);
                    return Expression.MakeMemberAccess(expr, node.Member);
                }
                return base.VisitMember(node);
            }
            protected override Expression VisitLambda<T>(Expression<T> node)
            {
                bool initialMode = InitialMode;
                InitialMode = false;
                Expression<T> expr = (Expression<T>)base.VisitLambda<T>(node);
                if (initialMode)
                {
                    ResultExpression = Expression.Lambda<Func<TInput, TConverted>>(expr.Body,SubPathParameter);
                }
                return expr;
            }
        }
