    public abstract class Beverage
    {
        public abstract double Cost { get; }
        public virtual Description { get; set; } = "unknown beverage";
    }
