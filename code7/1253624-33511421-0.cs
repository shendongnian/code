    class JoinOptionsExpression: JoinExpression {
        public IEnumerable<JoinExpression> Options {get; private set;}
        private JoinOptionsExpression(){}
        public static JoinOptionsExpression Create(IEnumerable<JoinExpression> options){
            return new JoinOptionsExpression{Options = options.ToList().AsReadOnly()}; // you can improve this probably
        }
    }
