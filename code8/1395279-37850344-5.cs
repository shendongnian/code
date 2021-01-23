    class Program
    {
        static void Main(string[] args)
        {
            List<int[]> intArrList = new List<int[]>();
            intArrList.Add(new int[3] { 0, 0, 0 });
            intArrList.Add(new int[5] { 20, 30, 10, 4, 6 });  //this
            intArrList.Add(new int[3] { 1, 2, 5 });
            intArrList.Add(new int[5] { 20, 30, 10, 4, 6 });  //this
            intArrList.Add(new int[3] { 12, 22, 54 });
            intArrList.Add(new int[5] { 1, 2, 6, 7, 8 });
            intArrList.Add(new int[4] { 0, 0, 0, 0 });
            var test = intArrList.Distinct(new IntArrayEqualityComparer());
            Console.WriteLine(test.Count());
            Console.WriteLine(intArrList.Count());
        }
        public class IntArrayEqualityComparer : IEqualityComparer<int[]>
        {
            public bool Equals(int[] x, int[] y)
            {
                return ArraysEqual(x, y);
            }
            public int GetHashCode(int[] obj)
            {
                int hc = obj.Length;
                for (int i = 0; i < obj.Length; ++i)
                {
                    hc = unchecked(hc * 17 + obj[i]);
                }
                return hc;
            }
            static bool ArraysEqual<T>(T[] a1, T[] a2)
            {
                if (ReferenceEquals(a1, a2))
                    return true;
                if (a1 == null || a2 == null)
                    return false;
                if (a1.Length != a2.Length)
                    return false;
                EqualityComparer<T> comparer = EqualityComparer<T>.Default;
                for (int i = 0; i < a1.Length; i++)
                {
                    if (!comparer.Equals(a1[i], a2[i])) return false;
                }
                return true;
            }
        }
    }
