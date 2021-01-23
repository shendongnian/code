    public abstract class CarFactoryParams { }
    public class Car1FactoryParams : CarFactoryParams
    {
       public Car1FactoryParams(Dep1, Dep2, Dep3) 
       { 
          this.Dep1 = Dep1;
          ...
    }
    public class Car2FactoryParams 
          ...
    public class CarFactory
    {
        public ICar CreateCar( CarFactoryParams params )
        {
            if ( params is Car1FactoryParams )
            {
                var cp = (Car1FactoryParams)params;
                return new Car1( cp.Dep1, cp.Dep2, ... );
            }
            ...
            if ( params is ...
