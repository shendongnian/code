    public class Services
    {
        public Services()
        {
            Console.WriteLine("Base Constructor Services()");
        }
    }
    public class Packages : Services
    {
        public Packages()
	        : base()
        {
	        Console.WriteLine("Derived constructor Packages()");
        }
    }
    public class ClientContract : Services
    {
        public ClientContract()
	        : base()
        {
	        Console.WriteLine("Derived constructor ClientContract()");
        }
    }
    public class Client: Services
    {
        public Client()
	        : base()
        {
	        Console.WriteLine("Derived constructor Client()");
        }
    }
    public class Individual : Services
    {
        public Individual()
	        : base()
        {
	        Console.WriteLine("Derived constructor Individual()");
        }
    }
