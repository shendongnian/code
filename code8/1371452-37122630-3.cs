    public class Services
    {
        public Services()
        {
            Console.WriteLine("Base Constructor Services()");
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
