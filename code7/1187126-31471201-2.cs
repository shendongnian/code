    public class UniqueIDStingOnly
    {
        private static long last = 0;
        private static char[] chars = { '0', '1', '2', '3', '4', '5', '6' };
        private static char[] chars2 = { 'A', 'B', 'C', 'D', 'E', 'F' };
        public String Next()
        {
            StringBuilder sb = new StringBuilder();
            long cur = last;
            do
            {
                int mod = (int)cur % 6;
                sb.Append(chars2[mod]);
                cur /= 6;
            } while (cur > 0);
            ++last;
            while (sb.Length < 32) sb.Append("A");
            return sb.ToString();
        }
    }
    public class Program
    {
        public static UniqueIDStingOnly uid = new UniqueIDStingOnly();
        private static void Main(string[] args)
        {
            for (int a = 0; a < 1000; a++)
            {
                string s = uid.Next();
                Guid g = new Guid(s);
                Console.WriteLine("" + a + " becomes : " + g.ToString("D"));
            }
        }
    }
