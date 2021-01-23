    public abstract class Duck
    {
        public abstract string Quack();
        public double Weight { get; set; }
    
        public Duck(double weight)
        {
            Contract.Requires(weight > 0);
            this.Weight = weight;
        }
    }
    
    public class WildDuck : Duck
    {
        public WildDuck(double weight)
            : base(weight)
        {
            Contract.Requires(weight > 0);
            this.Weight = weight;
        }
    
        public override string Quack()
        {
            return "wild quack";
        }
    }
