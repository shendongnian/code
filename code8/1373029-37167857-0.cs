    public class Instantiator
    {
        public static Instance Instantiate()
        {
            Instance instance = new Instance();
            instance.OnInstantiated();
            return instance;
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var instance = Instantiator.Instantiate();
            Referent.Refer(instance);
            Console.ReadLine();
        }
    }
