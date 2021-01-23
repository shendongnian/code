        public class Program
        {
            public static void Main(string[] args)
            {
                //Your code goes here
                Console.WriteLine(string.Format("{0:0.00}", 35));
                Console.WriteLine(string.Format("{0:0.00}", "35"));
                Console.WriteLine(string.Format("{0:0.00}", int.Parse("35")));
            }
        }
