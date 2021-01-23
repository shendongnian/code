    public abstract class Car
    {
        virtual Ignition ignition;
        virtual void Start(){ ignition = A;}
        public void Run(){
                Start();
        }
    }
    
    public class Sedan : Car
    {
        override void Start(){ ignition = B;}
    }
    
    public class SUV : Car
    {
        override void Start(){ ignition = C;}
    }
