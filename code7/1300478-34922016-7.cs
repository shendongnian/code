        private static String Remove(String s)
        {
            var rs = s.Split(new[] { '"' }).ToList();
            var mod = s.IndexOf('"') < s.IndexOf(rs.First()) ? 1 : 2;
            return String.Join("\"\"", rs.Where(_ => rs.IndexOf(_) % mod == 0));
        }
    
        static void Main(string[] args)
        {
            var test = Remove("hello\"world\"\"yeah\" test \"fhfh\"");
            return;
        }
