    class Program
    {
        static void Main(string[] args)
        {
            Instance.Instantiate();
            Referent.Refer(Instance.GetInstance());
            Console.ReadLine();
        }
    }
    public class Instance
    {
        private static Instance myInstance;
        public void OnInstantiated()
        {
            Console.WriteLine("I have been instantiated.");
        }
        public void OnReferred()
        {
            Console.WriteLine("I have been referred to.");
        }
        public static void Instantiate()
        {
            myInstance = new Instance();
            myInstance.OnInstantiated();
        }
        public static Instance GetInstance()
        {
            return myInstance;
        }
    }
    public class Referent
    {
        public static void Refer(Instance instance)
        {
            if (instance != null)
            {
                instance.OnReferred();
            }
            else
            {
                Console.WriteLine("No instance to refer to.");
            }
        }
    }
