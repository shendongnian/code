    public class xxx
    {
        private yyy ggg;
        public xxx()
        {
            ggg = new yyy(this); // "this" redlined by C# Express
        }
    }
    public class yyy
    {
        public yyy(xxx InstantiatedBy)
        {
            MyInstantiator = InstantiatedBy;
        }
        xxx MyInstantiator = new xxx();
    }
