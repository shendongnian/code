    public class Program
    {
        [Flags]
        enum Enum:int
        {
            a = 1,
            b = 2
        }
        
        static void Main(string[] args)
        {
            Enum x = (Enum) 3;
            Console.WriteLine(x.ToString());
        }
    }
