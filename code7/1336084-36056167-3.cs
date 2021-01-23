    public delegate double CalculateDelegate(double x, double y);
    
    public class Test
    {        
        public CalculateDelegate calculate;                
    }
    
    public class DelegateContainer
    {
        public double Add(double x, double y)
        {
            return x + y;
        }
        public double Subtract(double x, double y)
        {
            return x - y;
        }
    
        public Dictionary<string, CalculateDelegate> collection = new Dictionary<string, CalculateDelegate>();
        public DelegateContainer()
        {
            collection["Add"] = Add;
            collection["Subtract"] = Subtract;
        }
    
        public CalculateDelegate this[string name]
        {            
            get
            {                
                return collection[name];
            }            
        }
    }
    
    public static void Main()
    {        
        var target = new Test();
        var container = new DelegateContainer();
        target.calculate = container["Add"];
        Console.WriteLine("1 + 2 = " + target.calculate(1, 2));
        target.calculate = container["Subtract"];
        Console.WriteLine("5 - 2 = " + target.calculate(5, 2));
    }
