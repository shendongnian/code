    public class C
    {
        public IFoo M(int i)
        {
            return (i == 0) ? new Bar() : new Biz();
        }
    }
