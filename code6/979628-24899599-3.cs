    public abstract class BaseCar<TDriver> 
        where TDriver : BaseDriver
    {
        public abstract TDriver Driver { get; }
    }
    public abstract class BaseDriver
    {
        public abstract string Name { get; set; }
    }
    public class AgressiveDriver : BaseDriver
    {
        public override string Name { get; set; }
    }
    public class FastCar : BaseCar<AgressiveDriver>
    {
        private AgressiveDriver _agressiveDriver = new AgressiveDriver();
        public override AgressiveDriver Driver { get { return _agressiveDriver; } }
    }
