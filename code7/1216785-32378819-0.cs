    public class EvaluationVisitor : IVisitor<IExpression>
    {
        public IExpression Visit(Lit exp)
        {
            mValueStack.Push( exp.value );
            return exp;
        }
        public IExpression Visit(Plus exp)
        {
            exp.e1.Accept<IExpression>( this );
            exp.e2.Accept<IExpression>( this );
            int v2 = mValueStack.Pop();
            int v1 = mValueStack.Pop();
            mValueStack.Push( v1 + v2 );
            return new Lit( v1 + v2 );
        }
        public int Value
        {
            get
            {
                if( mValueStack.Count != 1 )
                {
                    // Malformed expression, could throw an exception or something
                }
                return mValueStack.Peek();
            }
        }
        private readonly Stack<int> mValueStack = new Stack<int>();
    }
