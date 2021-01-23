    Console.WriteLine( BaseN.Encode(BaseN.Decode("AD5B7") + 1) );
    Console.WriteLine( BaseN.Encode(BaseN.Decode("1ZZZZ") + 1) );
    Console.WriteLine( BaseN.Encode(BaseN.Decode("ZZZZZ") + 1) );
---
    public static class BaseN
    {
        static List<char> CHARSET = new List<char>("0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ");
                
        public static String Encode(BigInteger input)
        {
            var stack = new Stack<char>();
            while (input != 0)
            {
                stack.Push(CHARSET[(int)(input % CHARSET.Count)]);
                input /= CHARSET.Count;
            }
            return new string(stack.ToArray());
        }
        
        public static BigInteger Decode(string input)
        {
            long sum = 0;
            int i = 0;
            foreach (char c in input.Reverse())
            {
                sum += CHARSET.IndexOf(c) * (long)Math.Pow(CHARSET.Count, i++);
            }
            return sum;
        }
    }
