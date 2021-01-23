    public abstract class BaseMathsClass {
        protected int Mult(int a, int b) {
            return a * b;
        }
    }
    public class ConcreteMathClass : BaseMathsClass {
        public int Square(int x) {
            return Mult(x, x);
        }
    }
