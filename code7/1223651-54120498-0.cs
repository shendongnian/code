    public static class IntExt
    {
        const string Symbols = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        public static string ToString(this int value, int toBase)
        {
            switch (toBase)
            {
                case 2:
                case 8:
                case 10:
                case 16:
                    return Convert.ToString(value, toBase);
                case 64:
                    return Convert.ToBase64String(BitConverter.GetBytes(value));
                default:
                    if (toBase < 2 || toBase > Symbols.Length)
                        throw new ArgumentOutOfRangeException(nameof(toBase));
                    if (value < 0)
                        throw new ArgumentOutOfRangeException(nameof(value));
                    int resultLength = 1 + (int)Math.Max(Math.Log(value, toBase), 0);
                    char[] results = new char[resultLength];
                    int num = value;
                    int index = resultLength - 1;
                    do
                    {
                        results[index--] = Symbols[num % toBase];
                        num /= toBase;
                    }
                    while (num != 0);
                    return new string(results);
            }
        }
    }
    public class UnitTest1
    {
        public static T[][] GetJoinCombinations<T>(T[][] arrs)
        {
            int maxLength = 0;
            int total = 1;
            for (int i = 0; i < arrs.Length; i++)
            {
                T[] arr = arrs[i];
                maxLength = Math.Max(maxLength, arr.Length);
                total *= arr.Length;
            }
            T[][] results = new T[total][];
            int n = 0;
            int count = (int)Math.Pow(maxLength, arrs.Length);
            for (int i = 0; i < count; i++)
            {
                T[] combo = new T[arrs.Length];
                string indices = i.ToString(maxLength).PadLeft(arrs.Length, '0');
                bool skip = false;
                for (int j = 0; j < indices.Length; j++)
                {
                    T[] arr = arrs[j];
                    int index = int.Parse(indices[j].ToString());
                    if (index >= arr.Length)
                    {
                        skip = true;
                        break;
                    }
                    combo[j] = arr[index];
                }
                if (!skip)
                    results[n++] = combo;
            }
            return results;
        }
        [Fact]
        public void Test1()
        {
            string[][] results = GetJoinCombinations(new string[][]
            {
                new string[] { "1", "2", "3" },
                new string[] { "A", "B", "C" },
                new string[] { "+", "-", "*", "/" },
            });
        }
    }
