    public class Vehicle<TEngine> where TEngine: Engine
    {
        protected List<TEngine> engines = new List<TEngine>();
    
        public void StartAllEngines (){
            foreach (TEngine engine in this.engines){
                engine.Start();
            }
        }
    }
    
    public class ElectricCar: Vehicle<ElectricEngine>
    {
        public ElectricCar(){
        }
    }
    
    public class DieselCar: Vehicle<DieselEngine>
    {
        public DieselCar(){
        }
    }
    
    public class ElectricEngine: Engine {...}
    public class DieselEngine: Engine {...}
