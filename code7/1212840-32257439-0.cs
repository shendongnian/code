    class Program
    {
        static void Main(string[] args)
        {
            var target = new List<byte>();
            BitConverter.GetBytes(10).AddBytesToTarget(target);
            BitConverter.GetBytes(100d).AddBytesToTarget(target);
        }
    }
    static public class Extensions
    {
        public static void AddBytesToTarget(this IEnumerable<byte> bytes, List<byte> target)
        {
            target.AddRange(bytes);
        }
    }
