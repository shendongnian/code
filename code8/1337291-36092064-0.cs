    class Program
    {
        static void Main(string[] args)
        {
            var str = "[1,2,3,4,5,6,7,8,9]";
            var x = FromRubyArray(str);
            Console.WriteLine(str);
            Console.WriteLine(string.Join("-", x));
            Console.ReadLine();
        }
        public static List<ushort> FromRubyArray(string stra)
        {
            if (string.IsNullOrWhiteSpace(stra)) return new List<ushort>();
            stra = stra.Trim();
            stra = stra.Trim('[', ']');
                                  
            return stra                
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => Convert.ToUInt16(s))
                .ToList();
        }
    }
