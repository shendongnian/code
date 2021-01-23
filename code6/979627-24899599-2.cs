    public abstract class BaseCar
    {
        public abstract BaseDriver Driver { get; }
    }
    public abstract class BaseDriver
    {
        public abstract string Name { get; set; }
    }
    public class AgressiveDriver : BaseDriver
    {
        public override string Name { get; set; }
    }
    public class FastCar : BaseCar
    {
        private AgressiveDriver _agressiveDriver = new AgressiveDriver();
        public override BaseDriver Driver { get { return _agressiveDriver; } }
        public AgressiveDriver AgressiveDriver { get { return _agressiveDriver; } }
    }
