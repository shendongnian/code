        private static void RecursiveAdd(byte[] result, byte[] b, int index)
        {
            if (index < result.Length)
            {
                RecursiveAdd(result, b, index + 1);
                result[index] += b[index];
            }
        }
        public static byte[] Add(byte[] a, byte[] b)
        {
            var result = (byte[])a.Clone();
            RecursiveAdd(result, b, 0);
            return result;
        }
        static void Main(string[] args)
        {
            var r1 = Add(new byte[] { 1, 1, 1 }, new byte[] { 1, 1, 1 });
            var r2 = Add(new byte[] { 1, 1, 255 }, new byte[] { 0, 0, 1 });
            var r3 = Add(new byte[] { 0, 100, 200 }, new byte[] { 3, 2, 1 });
            // 2, 2, 2
            Console.WriteLine(string.Join(",", r1.Select(n => "" + n).ToArray()));
            // 1, 1, 0 (unchecked overflow on: 255 + 1 "=" 0)
            Console.WriteLine(string.Join(",", r2.Select(n => "" + n).ToArray()));
            // 3, 102, 201
            Console.WriteLine(string.Join(",", r3.Select(n => "" + n).ToArray()));
            Console.ReadKey();
        }
