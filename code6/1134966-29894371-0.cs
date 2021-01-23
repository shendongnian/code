        class V : ExpressionVisitor
        {
            public ParameterExpression Parameter { get; private set; }
            Expression m;
            public V(Type parameterType, string member)
            {
                Parameter = Expression.Parameter(parameterType);
                this.m = Expression.PropertyOrField(Parameter, member);
            }
            protected override Expression VisitParameter(ParameterExpression node)
            {
                if (node.Type == m.Type)
                {
                    return m;
                }
                return base.VisitParameter(node);
            }
        }
