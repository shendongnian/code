    using System.Runtime.InteropServices;
    ...
    public class Program
    {
        [DllImport("yourcppdll.dll")]
        public static extern int AddNumbers(int n1, int n2);
        static void Main(string[] args)
        {
            int result = AddNumbers(2, 2);
			
            //result equals 4
			Console.WriteLine("Result is " + result.ToString());
        }
    }
	
