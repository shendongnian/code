    namespace ConsoleApplication6
    {
        class Program
        {
            public static string SSN { get; set; }
            // Return a hash code based on a point of unique string data.
            public override int GetHashCode()
            {
                return SSN.GetHashCode();
            }
            public static void Main(string[] args)
            {
                Console.WriteLine("{0}", SSN);
            }
		}
	}
