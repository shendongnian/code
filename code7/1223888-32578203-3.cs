    void Main()
    {
        Human jamesDoe = new Human();
        ICar car = new BMW();
        
        jamesDoe.TestDriveCar(car);
    }
    
    public interface ICar 
    {
        void Accelerate();
        void Brake();
    }  
    
    public class BMW : ICar
    {
        private int x;
    
        public void Accelerate()
        {
            new int[150].ToList()
                        .ForEach(i => { Console.WriteLine("{0} MPH", x++); Thread.Sleep(50); });
        }
        public void Brake()
        {
            new int[150].ToList()
                        .ForEach(i => { Console.WriteLine("{0} MPH", x--); Thread.Sleep(50); });
        }
    }
    
    public class Human
    {
        public void TestDriveCar(ICar car)
        {
            car.Accelerate();
            car.Brake();
        }
    }
        
            
        
