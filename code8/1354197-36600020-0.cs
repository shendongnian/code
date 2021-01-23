        public class CostSpecification<T> : AbstractSpecification<T>
    {
        private int cost;
        public CostSpecification(int cost)
        {
            this.cost = cost;
        }
        public override bool IsSatisfiedBy(T o)
        {
            return (o as Foo).Cost >= this.cost;
        }
    }
