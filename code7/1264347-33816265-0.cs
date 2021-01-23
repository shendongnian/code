    public class Program
    {
        public static void Main(string[] args)
        {
            PrintHourGlass(25);
        }
        static void PrintHourGlass(int indent)
        {
            PrintAsteriks(indent, 5);
            PrintAsteriks(indent + 1, 3);
            PrintAsteriks(indent + 2, 1);
            PrintAsteriks(indent + 1, 3);
            PrintAsteriks(indent, 5);
        }
        static void PrintAsteriks(int indent, int asterisks)
        {
            string formatString = "{0," + indent + "}{1}";
            Console.WriteLine(formatString, null, new string('*', asterisks));
        }
    }
