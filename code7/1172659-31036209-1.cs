    void Add(Expression<Func<string>> fn)
    {
            if (fn.Body.NodeType != ExpressionType.Constant)
                throw new ArgumentException("Only literal strings are allowed");
            //and extra check if the value itself is interned
            var val = fn.Compile()();
            if (string.IsInterned(val) == null)
                throw new ArgumentException("Only literal strings are allowed");
    }
