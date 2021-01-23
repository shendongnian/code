    public static class QueryableExtensions
    {
        public static IQueryable<T> ReduceConstPredicates<T>(this IQueryable<T> source)
        {
            var reducer = new ConstPredicateReducer();
            var expression = reducer.Visit(source.Expression);
            if (expression == source.Expression) return source;
            return source.Provider.CreateQuery<T>(expression);
        }
    
        class ConstPredicateReducer : ExpressionVisitor
        {
            private int evaluateConst;
            private bool EvaluateConst { get { return evaluateConst > 0; } }
            private ConstantExpression TryEvaluateConst(Expression node)
            {
                evaluateConst++;
                try { return Visit(node) as ConstantExpression; }
                catch { return null; }
                finally { evaluateConst--; }
            }
            protected override Expression VisitUnary(UnaryExpression node)
            {
                if (EvaluateConst || node.Type == typeof(bool))
                {
                    var operandConst = TryEvaluateConst(node.Operand);
                    if (operandConst != null)
                    {
                        var result = Expression.Lambda(node.Update(operandConst)).Compile().DynamicInvoke();
                        return Expression.Constant(result, node.Type);
                    }
                }
                return EvaluateConst ? node : base.VisitUnary(node);
            }
            protected override Expression VisitBinary(BinaryExpression node)
            {
                if (EvaluateConst || node.Type == typeof(bool))
                {
                    var leftConst = TryEvaluateConst(node.Left);
                    if (leftConst != null)
                    {
                        if (node.NodeType == ExpressionType.AndAlso)
                            return (bool)leftConst.Value ? Visit(node.Right) : Expression.Constant(false);
                        if (node.NodeType == ExpressionType.OrElse)
                            return !(bool)leftConst.Value ? Visit(node.Right) : Expression.Constant(true);
                        var rightConst = TryEvaluateConst(node.Right);
                        if (rightConst != null)
                        {
                            var result = Expression.Lambda(node.Update(leftConst, node.Conversion, rightConst)).Compile().DynamicInvoke();
                            return Expression.Constant(result, node.Type);
                        }
                    }
                }
                return EvaluateConst ? node : base.VisitBinary(node);
            }
            protected override Expression VisitConditional(ConditionalExpression node)
            {
                if (EvaluateConst || node.Type == typeof(bool))
                {
                    var testConst = TryEvaluateConst(node.Test);
                    if (testConst != null)
                        return Visit((bool)testConst.Value ? node.IfTrue : node.IfFalse);
                }
                return EvaluateConst ? node : base.VisitConditional(node);
            }
            protected override Expression VisitMember(MemberExpression node)
            {
                if (EvaluateConst || node.Type == typeof(bool))
                {
                    var expressionConst = node.Expression != null ? TryEvaluateConst(node.Expression) : null;
                    if (expressionConst != null || node.Expression == null)
                    {
                        var result = Expression.Lambda(node.Update(expressionConst)).Compile().DynamicInvoke();
                        return Expression.Constant(result, node.Type);
                    }
                }
                return EvaluateConst ? node : base.VisitMember(node);
            }
            protected override Expression VisitMethodCall(MethodCallExpression node)
            {
                if (EvaluateConst || node.Type == typeof(bool))
                {
                    var objectConst = node.Object != null ? TryEvaluateConst(node.Object) : null;
                    if (objectConst != null || node.Object == null)
                    {
                        var argumentsConst = new ConstantExpression[node.Arguments.Count];
                        int count = 0;
                        while (count < argumentsConst.Length && (argumentsConst[count] = TryEvaluateConst(node.Arguments[count])) != null)
                            count++;
                        if (count == argumentsConst.Length)
                        {
                            var result = Expression.Lambda(node.Update(objectConst, argumentsConst)).Compile().DynamicInvoke();
                            return Expression.Constant(result, node.Type);
                        }
                    }
                }
                return EvaluateConst ? node : base.VisitMethodCall(node);
            }
        }
    }
