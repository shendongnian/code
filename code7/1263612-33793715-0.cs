    public interface IEngine
    {
        void Start();
    }
    public class ElectricEngine : IEngine {
        
        public void Start()
        {
            // start code
        }
    }
    public class Vehicle{
        protected List<IEngine> engines;
    
        public void StartAllEngines (){
            foreach (IEngine engine in this.engines){
                engine.Start();
            }
        }
    }
