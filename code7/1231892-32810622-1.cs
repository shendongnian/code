    public interface IExpression {
        public int Solve();
    }
    
    // class that will contain an integer number value
    public class ValueExpression : IExpression {
        public int Value { get; set; }
        public ValueExpression(int value) {
            Value = value;
        }
        public int Solve() {
            return Value;
        }
    }
    
    // class that will contain definition for expressions
    public class OperationExpression : IExpression {
        public IExpression Left { get; set; }
        public IExpression Right { get; set; }
        public Operations Operation { get; set; }
        public OperationExpression() { }
        public OperationExpression(IExpression left, IExpression right, Operations operation) {
            Left = left;
            Right = right;
            Operation = operation;
        }
        public enum Operations {
            MA,
            Minus,
            Add
            // other
        }
        public int Solve() {
            switch (Operation) {
                case MA :
                    // You will have to implement MA method
                    return MA(left.Solve(), right.Solve());
                case Minus :
                    return left.Solve().Minus(right.Solve());
                case Add :
                    return left.Solve().Add(right.Solve());
            }
        }
    }
