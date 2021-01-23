    /// <summary>
    /// Helps in building expressions.
    /// </summary>
    public static class Express
    {
        #region Prepare
        /// <summary>
        /// Prepares an expression to be used in queryables.
        /// </summary>
        /// <returns>The modified expression.</returns>
        /// <remarks>
        /// The method replaces occurrences of <see cref="LambdaExpression"/>.Compile().Invoke(...) with the body of the lambda, with it's parameters replaced by the arguments of the invocation.
        /// Values are resolved by evaluating properties and fields only.
        /// </remarks>
        public static Expression<TDelegate> Prepare<TDelegate>(this Expression<TDelegate> lambda) => (Expression<TDelegate>)new PrepareVisitor().Visit(lambda);
        /// <summary>
        /// Wrapper for <see cref="Prepare{TDelegate}(Expression{TDelegate})"/>.
        /// </summary>
        public static Expression<Func<T1, TResult>> Prepare<T1, TResult>(Expression<Func<T1, TResult>> lambda) => lambda.Prepare();
        /// <summary>
        /// Wrapper for <see cref="Prepare{TDelegate}(Expression{TDelegate})"/>.
        /// </summary>
        public static Expression<Func<T1, T2, TResult>> Prepare<T1, T2, TResult>(Expression<Func<T1, T2, TResult>> lambda) => lambda.Prepare();
        // NOTE: more overloads of Prepare here.
        #endregion
        /// <summary>
        /// Evaluate an expression to a simple value.
        /// </summary>
        private static object GetValue(Expression x)
        {
            switch (x.NodeType)
            {
                case ExpressionType.Constant:
                    return ((ConstantExpression)x).Value;
                case ExpressionType.MemberAccess:
                    var xMember = (MemberExpression)x;
                    var instance = xMember.Expression == null ? null : GetValue(xMember.Expression);
                    switch (xMember.Member.MemberType)
                    {
                        case MemberTypes.Field:
                            return ((FieldInfo)xMember.Member).GetValue(instance);
                        case MemberTypes.Property:
                            return ((PropertyInfo)xMember.Member).GetValue(instance);
                        default:
                            throw new Exception(xMember.Member.MemberType + "???");
                    }
                default:
                    // NOTE: it would be easy to compile and invoke the expression, but it's intentionally not done. Callers can always pre-evaluate and pass a captured member.
                    throw new NotSupportedException("Only constant, field or property supported.");
            }
        }
        /// <summary>
        /// <see cref="ExpressionVisitor"/> for <see cref="Prepare{TDelegate}(Expression{TDelegate})"/>.
        /// </summary>
        private sealed class PrepareVisitor : ExpressionVisitor
        {
            /// <summary>
            /// Replace lambda.Compile().Invoke(...) with lambda's body, where the parameters are replaced with the invocation's arguments.
            /// </summary>
            protected override Expression VisitInvocation(InvocationExpression node)
            {
                // is it what we are looking for?
                var call = node.Expression as MethodCallExpression;
                if (call == null || call.Method.Name != "Compile" || call.Arguments.Count != 0 || call.Object == null || !typeof(LambdaExpression).IsAssignableFrom(call.Object.Type))
                    return base.VisitInvocation(node);
                // get the lambda
                var lambda = call.Object as LambdaExpression ?? (LambdaExpression)GetValue(call.Object);
                // get the expressions for the lambda's parameters
                var replacements = lambda.Parameters.Zip(node.Arguments, (p, x) => new KeyValuePair<ParameterExpression, Expression>(p, x));
                // return the body with the parameters replaced
                return Visit(new ParameterReplaceVisitor(replacements).Visit(lambda.Body));
            }
        }
        /// <summary>
        /// <see cref="ExpressionVisitor"/> to replace parameters with actual expressions.
        /// </summary>
        private sealed class ParameterReplaceVisitor : ExpressionVisitor
        {
            private readonly Dictionary<ParameterExpression, Expression> _replacements;
            /// <summary>
            /// Init.
            /// </summary>
            /// <param name="replacements">Parameters and their respective replacements.</param>
            public ParameterReplaceVisitor(IEnumerable<KeyValuePair<ParameterExpression, Expression>> replacements)
            {
                _replacements = replacements.ToDictionary(kv => kv.Key, kv => kv.Value);
            }
            protected override Expression VisitParameter(ParameterExpression node)
            {
                Expression replacement;
                return _replacements.TryGetValue(node, out replacement) ? replacement : node;
            }
        }
    }
