    class ExpressionStringBuilder : ExpressionVisitor
    {
        private readonly StringBuilder _out;
        public ExpressionStringBuilder()
        {
            _out = new StringBuilder();
        }
        protected override Expression VisitConstant(ConstantExpression node)
        {
            if (node.Value != null)
            {
                var text = node.Value.ToString();
                if (node.Value is string)
                {
                    Out("\"");
                    Out(text);
                    Out("\"");
                }
                else if (text == node.Value.GetType().ToString())
                {
                    Out("_");
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
            var num = 0;
            var expression = node.Object;
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
            var i = num;
            var count = node.Arguments.Count;
            while (i < count)
            {
                if (i > num)
                {
                    Out(", ");
                }
                Visit(node.Arguments[i]);
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
                Visit(expression);
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
