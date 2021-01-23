    public class Car2016Model : Control
    {
        public Engine Engine { get; set; }
    }
    public class Engine
    {
        public virtual double Power => 0;
    }
    public class Engine2016 : Engine
    {
        public override double Power => 1000;
    }
    public class Engine2015 : Engine
     {
        public override double Power => 350;
    }
