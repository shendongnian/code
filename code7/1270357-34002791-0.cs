    using System.ComponentModel;
    public interface IHeater
    {
        int Temperature { get; set; }
    }
    public class Heater : Component, IHeater
    {
        public int Temperature 
        {
            get;
            set;
        }
    }
    
    public class HeaterMonitor:Component
    {
        public IHeater Source { get; set; }
    }
