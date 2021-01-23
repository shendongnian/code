    public class EvaluationVisitor : IVisitor<int>
    {
        public int Visit(Lit exp)
        {
            return exp.value;
        }
        public int Visit(Plus exp)
        {
            int v1 = exp.e1.Accept<int>( this );
            int v2 = exp.e2.Accept<int>( this );
            return v1 + v2;
        }
    }
