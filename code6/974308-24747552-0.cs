        /// <summary>
        /// Combines two lambda expressions into a single expression.
        /// In the returned expression, the parameter in the second expression will be replaced
        /// with the parameter from the first.
        /// </summary>
        /// <param name="source">The first expression to combine.</param>
        /// <param name="other">The second expression to combine.</param>
        /// <param name="combiner">
        /// How to combine the expression bodies.
        /// Example: <see cref="Expression.Or(System.Linq.Expressions.Expression,System.Linq.Expressions.Expression)"/>
        /// </param>
        /// <returns></returns>
        public static Expression<Func<T1, T2>> Combine<T1, T2>(
            this Expression<Func<T1, T2>> source,
            Expression<Func<T1, T2>> other,
            Func<Expression, Expression, BinaryExpression> combiner)
        {
            var sourceParam = source.Parameters[0];
            var visitor = new ParameterReplacerVisitor(other.Parameters[0], sourceParam);
            var visitedOther = visitor.VisitAndConvert(other, "Combine");
            Require.That(visitedOther != null, () => "VisitAndConvert failed to return a value.");
            var newBody = combiner(source.Body, visitedOther.Body);
            return newBody.ToLambda<Func<T1, T2>>(sourceParam);
        }
