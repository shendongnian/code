        private static void RecursiveAdd(byte[] result, byte[] b, int remaining)
        {
            if (remaining > 0)
            {
                RecursiveAdd(result, b, remaining - 1);
                result[remaining - 1] += b[remaining - 1];
            }
        }
        public static byte[] Add(byte[] a, byte[] b)
        {
            var result = (byte[])a.Clone();
            RecursiveAdd(result, b, a.Length);
            return result;
        }
        static void Main(string[] args)
        {
            var r1 = Add(new byte[] { 1, 1, 1 }, new byte[] { 1, 1, 1 });
            var r2 = Add(new byte[] { 1, 1, 255 }, new byte[] { 0, 0, 1 });
            var r3 = Add(new byte[] { 0, 100, 200 }, new byte[] { 3, 2, 1 });
            // 2, 2, 2
            Console.WriteLine(string.Join(",", r1.Select(n => "" + n).ToArray()));
            // 1, 1, 0 (as expected, unchecked overflow on: 255 + 1 "=" 0)
            Console.WriteLine(string.Join(",", r2.Select(n => "" + n).ToArray()));
            // 3, 102, 201
            Console.WriteLine(string.Join(",", r3.Select(n => "" + n).ToArray()));
            Console.ReadKey();
        }
