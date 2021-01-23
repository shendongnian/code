        public class QueryContext<T>
        {
            void Execute(MethodCallExpression dsQueryExpression)
            {
                var orderByFinder = new OrderByFinder();
                var orderByExpression = orderByFinder.GetOrderBy(dsQueryExpression);
                // .. Continue on processing the OrderBy expression
            }
        }
    
        internal class OrderByFinder : ExpressionVisitor
        {
            MethodCallExpression _orderByExpression;
    
            public MethodCallExpression GetOrderBy(Expression expression)
            {
                Visit(expression);
                return _orderByExpression;
            }
    
            protected override Expression VisitMethodCall(MethodCallExpression expression)
            {
                if (expression.Method.Name == "OrderBy") _orderByExpression = expression;
    
                Visit(expression.Arguments[0]);
    
                return expression;
            }
        }
