    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(0.Sign()); 
            Console.WriteLine(0.SignName());
            Console.WriteLine(12.Sign());
            Console.WriteLine(12.SignName());
            Console.WriteLine((-15).Sign());
            Console.WriteLine((-15).SignName());
            Console.ReadLine();
        }
    }
    public static class extensions
    {
        public static string Sign(this int signedNumber)
        {
            return (signedNumber.ToString("+00;-00").Substring(0, 1));
        }
        public static string SignName(this int signedNumber)
        {
            return (signedNumber.ToString("+00;-00").Substring(0, 1)=="+"?"positive":"negative");
        }
    }
