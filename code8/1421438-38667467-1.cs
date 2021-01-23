    public class Mocha : Beverage
    {
        Beverage beverage;
        public Mocha(Beverage beverage)
        {
            this.beverage = beverage;
        }
        public override string Description
        {
            get { return beverage.Description + ", Mocha"; }
            set { throw InvalidOperationException("Cannot Set Value of Decorator"); }
        }
        public override double Cost => .20 + beverage.Cost;
    }
