    public class A
    {
        public A()
        {
            NewUniqueValue = Generate();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string NewUniqueValue { get; set; }
        public static string Generate()
        {
            Random rnd = new Random();
            var chars = "abcdef0123456789";
            var unique = String.Empty;
            for (int i = 0; i < 20; i++)
            {
                unique += chars[rnd.Next(0, chars.Length)];
            }
            return unique;
        }
    }
