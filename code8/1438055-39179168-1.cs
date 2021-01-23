    class Program
    {
        static void Main(string[] args)
        {
            var foo = DateTime.Now;            
        }
    }
    public static class DateTime
    {
        public static System.DateTime Now => new System.DateTime(1900, 1, 1);
    }
