        public class CostSpecification : AbstractSpecification<Foo>
    {
        private int cost;
        public CostSpecification(int cost)
        {
            this.cost = cost;
        }
        public override bool IsSatisfiedBy(Foo o)
        {
            return o.Cost >= this.cost;
        }
    }
