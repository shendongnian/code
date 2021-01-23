    public static class ContainerExtensions
    {
        public static IEnumerable<InstanceProducer> GetInstanceProducers(this Container container)
        {
            return container.GetCurrentRegistrations()
                .SelectMany(GetExpressionTypes)
                .Distinct()
                .Select(container.GetRegistration);
        }
        private static IEnumerable<Type> GetExpressionTypes(InstanceProducer instanceProducer)
        {
            var expression = instanceProducer.BuildExpression();
            var visitor = new TypeExpressionVisitor();
            visitor.Visit(expression);
            return visitor.Types;
        }
        private class TypeExpressionVisitor : ExpressionVisitor
        {
            private readonly List<Type> _types;
            public IEnumerable<Type> Types
            {
                get { return _types; }
            }
            public TypeExpressionVisitor()
            {
                _types = new List<Type>();
            }
            protected override Expression VisitNew(NewExpression node)
            {
                _types.Add(node.Type);
                return base.VisitNew(node);
            }
            protected override Expression VisitInvocation(InvocationExpression node)
            {
                _types.Add(node.Type);
                return base.VisitInvocation(node);
            }
        }
    }
