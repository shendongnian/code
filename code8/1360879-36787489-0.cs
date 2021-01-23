    public abstract class CarCreationParams { }
    public class FordCreationParams : CarCreationParams
    {
        public Engine engine;
    }
    ...
 
    public class CarFactory
    {
        public Car GetCar( CarCreationParams parms )
        {
            if ( parms is FordCreationParams )
                return new Ford( ((FordCreationParams)parms).engine );
            ...
