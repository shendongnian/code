    public class Vehicle{
        protected Engine engine;
        public void Start (){
            engine.Start();
        }
    }
    public class ElectricCar : Vehicle
    {
        public ElectricCar(){
            engine = new ElectricEngine();
        }
        public void Start()
        {
            
        }
    }
    public class DieselCar: Vehicle
    {
        
        public DieselCar(){
            engine = new DieselEngine();
        }
    }
    public class ElectricEngine : Engine
    {
        public override void Start()
        {
            //Start Electric Engine
        }
    }
    public class DieselEngine: Engine {
        public override void Start()
        {
            //Start Diesel Engine
        }
    }
    public abstract class Engine
    {
        public abstract void Start();
    }
