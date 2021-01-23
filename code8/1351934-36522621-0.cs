	namespace Test
	{
	    class Program
	    {
	        public double AverageThree(double one, double two, double three)
	        {
	            return (one * two * three) / 3;
	        }
	        static void Main(string[] args)
	        {
	            Program p = new Program();
	            Console.WriteLine(p.AverageThree(3.7, 56, 998.321));
	        }
	    }
	}
