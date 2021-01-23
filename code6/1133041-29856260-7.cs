    public static class Calculator
    {
        public static int Evaluate(string expression)
        {
            var lexer = new BasicMathLexer(new AntlrInputStream(expression));
            lexer.RemoveErrorListeners(); //removes the default console listener
            lexer.AddErrorListener(new ThrowExceptionErrorListener());
            var tokens = new CommonTokenStream(lexer);
            var parser = new BasicMathParser(tokens);
            var tree = parser.compileUnit();
            var visitor = new IntegerMathVisitor();
            return visitor.Visit(tree);
        }
    }
