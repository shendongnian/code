    public abstract class Car<T> { public virtual T Engine { get; set; } }
    public class GasolineCar : Car<GasolineEngine> {}
    public class ElectricCar : Car<ElectricEngine>{}
    public abstract class Engine { public string Location; }
    public class GasolineEngine : Engine { int MPG; }
    public class ElectricEngine : Engine { int Cells; }
