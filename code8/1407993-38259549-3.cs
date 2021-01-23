    public static string ToMemberAccess<TResult>(Expression<Func<TResult>> expression, bool compileConstants = false)
    {
        var builder = new ExpressionStringBuilder(compileConstants);
        builder.Visit(expression);
        return builder.ToString();
    }
    internal class ExpressionStringBuilder : ExpressionVisitor
    {
        private readonly bool _compileConstants;
        private readonly StringBuilder _out;
        public ExpressionStringBuilder(bool compileConstants)
        {
            _compileConstants = compileConstants;
            _out = new StringBuilder();
        }
        protected override Expression VisitConstant(ConstantExpression node)
        {
            if (node.Value != null)
            {
                string text = node.Value.ToString();
                if (node.Value is string)
                {
                    Out("\"");
                    Out(text);
                    Out("\"");
                }
                else if (text == node.Value.GetType().ToString())
                {
                    Out('_');
                }
                else
                {
                    Out(text);
                }
            }
            else
            {
                Out("null");
            }
            return node;
        }
        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            int num = 0;
            Expression expression = node.Object;
            if (Attribute.GetCustomAttribute(node.Method, typeof(ExtensionAttribute)) != null)
            {
                num = 1;
                expression = node.Arguments[0];
            }
            var name = node.Method.Name;
            var isIndexer = name == "get_Item";
            if (expression != null)
            {
                Visit(expression);
                if (!isIndexer)
                {
                    Out('.');
                }
            }
            if (isIndexer)
                Out('[');
            else
            {
                Out(name);
                Out('(');
            }
            int i = num;
            int count = node.Arguments.Count;
            while (i < count)
            {
                if (i > num)
                {
                    Out(", ");
                }
                VisitArgument(node.Arguments[i]);
                i++;
            }
            Out(isIndexer ? ']' : ')');
            return node;
        }
        protected override Expression VisitIndex(IndexExpression node)
        {
            if (node.Object != null)
            {
                Visit(node.Object);
            }
            else
            {
                Out(node.Indexer.DeclaringType.Name);
            }
            if (node.Indexer != null)
            {
                Out(".");
                Out(node.Indexer.Name);
            }
            Out('[');
            for (var index = 0; index < node.Arguments.Count; index++)
            {
                if (index > 0)
                {
                    Out(", ");
                }
                var expression = node.Arguments[index];
                VisitArgument(expression);
            }
            Out(']');
            return node;
        }
        protected override Expression VisitLambda<T>(Expression<T> node)
        {
            Visit(node.Body);
            return node;
        }
        protected override Expression VisitMember(MemberExpression node)
        {
            OutMember(node.Expression, node.Member);
            return node;
        }
        public override string ToString()
        {
            return _out.ToString();
        }
        private void VisitArgument(Expression expression)
        {
            if (_compileConstants)
            {
                // TODO: possibly check the expression is not dependent on parameters
                var value = Expression.Lambda(expression).Compile().DynamicInvoke();
                Out(value + string.Empty);
            }
            else
            {
                VisitArgument(expression);
            }
        }
        private void OutMember(Expression instance, MemberInfo member)
        {
            if (instance != null)
            {
                Visit(instance);
                if (_out.Length > 0)
                    Out('.');
                Out(member.Name);
                return;
            }
            Out(member.DeclaringType.Name + "." + member.Name);
        }
        private void Out(char c)
        {
            _out.Append(c);
        }
        private void Out(string s)
        {
            _out.Append(s);
        }
    }
