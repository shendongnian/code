    public class BarProxy
    {
        private readonly IBar left;
        private readonly IBar right;
        public BarProxy(IBar left, IBar right) {
            this.left = left;
            this.right = right;
        }
        public void BarMethod(BarOperation op) {
            this.GetBar(op).BarMethod(op);
        }
        private IBar GetBar(BarOperation op) {
            return op.SomeValue ? this.left : this.right;
        }
    }
