    static void Main(string[] args)
        {
            var mybaseobject = new object[,]
            {
                {"Ranjith", "Murthy", "21"},
                {"Rohith", "M", "22"},
                {"Ranjith", "Murthy", "21"},
                {"varsha", "MJ", "18"}
            };
            var res = ToEnumerableOfEnumerable(mybaseobject).ToList();
            var dist = res.Distinct(new SimpleComparer());
        }
        public class SimpleComparer : IEqualityComparer<List<object>>
        {
            public bool Equals(List<object> x, List<object> y)
            {
                var l1 = x[0];
                var l2 = x[1];
                var r1 = y[0];
                var r2 = y[1];
                return r1 + "" == l1 + "" && l2 + "" == r2 + "";
            }
            public int GetHashCode(List<object> obj)
            {
                return 0;
            }
        }
        public static IEnumerable<List<T>> ToEnumerableOfEnumerable<T>(T[,] array)
        {
            int rowCount = array.GetLength(0);
            int columnCount = array.GetLength(1);
            for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
            {
                var row = new List<T>();
                for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
                {
                    row.Add(array[rowIndex, columnIndex]);
                }
                yield return row;
            }
        }
