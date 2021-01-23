    public abstract class Car { public virtual Engine Engine { get; set; } }
    public class GasolineCar : Car {
        private GasolineEngine _engine;
        public override Engine Engine { get { return _engine; } set { this._engine = (GasolineEngine)value; } }
    }
    public class ElectricCar : Car
    {
        private ElectricEngine _engine;
        public override Engine Engine { get { return _engine; } set { this._engine = (ElectricEngine)value; } }
    }
    public abstract class Engine { public string Location; }
    public class GasolineEngine : Engine { int MPG; }
    public class ElectricEngine : Engine { int Cells; }
