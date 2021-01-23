        private static String Remove(String s)
        {
            var indexes = new List<int>();
            Int32 i = 0;
            do
            {
                i = s.IndexOf('\"', i);
                if (i == -1) break;
                indexes.Add(s.IndexOf('\"', i++));
            } while (true);
            var result = s.Substring(0, indexes.First() + 1);
            for (int j = 1; j < indexes.Count; j += 2)
            {
                result +=
                    (j == indexes.Count - 1) ? s.Substring(indexes[j]) :
                    s.Substring(indexes[j], indexes[j + 1] - indexes[j] + 1);
            }
            return result;
        }
        static void Main(string[] args)
        {
            var test = Remove("hello\"world\"\"yeah\" test \"fhfh\"");
            return;
        }
