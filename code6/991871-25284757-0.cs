    class ReplaceMethodCallVisitor : ExpressionVisitor
    {
        readonly MethodInfo methodToReplace;
        readonly Func<IReadOnlyList<Expression>, Expression> replacementFunction;
        public ReplaceMethodCallVisitor(
            MethodInfo methodToReplace,
            Func<IReadOnlyList<Expression>, Expression> replacementFunction)
        {
            this.methodToReplace = methodToReplace;
            this.replacementFunction = replacementFunction;
        }
        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            if (node.Method == methodToReplace)
                return replacementFunction(node.Arguments);
            return base.VisitMethodCall(node);
        }
    }
