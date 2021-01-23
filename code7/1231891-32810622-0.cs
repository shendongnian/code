    public interface IExpression {
        public int Solve();
    }
    
    // class that will contain an integer number value
    public class ValueExpression : IExpression {
        public int Value { get; set; }
        public int Solve() {
            return Value;
        }
    }
    
    // class that will contain definition for expressions
    public class OperationExpression : IExpression {
        public IExpression Left { get; set; }
        public IExpression Right { get; set; }
        public Operations Operation { get; set; }
        public enum Operations {
            MA,
            Minus,
            Add
            // other
        }
        public int Solve() {
            switch (Operation) {
                case MA :
                    return MA(left.Solve(), right.Solve());
                case Minus :
                    return left.Solve().Minus(right.Solve());
                case Add :
                    return left.Solve().Add(right.Solve());
            }
        }
    }
