    public class ElectricDuck : Duck
    {
        public Battery Battery { get; set; }
    
        public override string Quack()
        {
            return "electric quack";
        }
    
        public ElectricDuck(double weight, Battery battery)
            : base(weight)
        {
            Contract.Requires(weight > 0);
            Contract.Requires(battery != null);
            this.Weight = weight;
            this.Battery = battery;
        }
    }
    
    public class Battery
    {
        public bool IsEmpty { get; set; }
    }
