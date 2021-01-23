    private static String Remove(String s)
    {
        var index = s.IndexOf('"');
        if (index == 0) index = -1;
        var rs = s.Split(new[] { '"' }).ToList();
        return String.Join("\"\"", rs.Where(_ => (rs.IndexOf(_)+index+1) % 2 == 0));
    }
    static void Main(string[] args)
    {
        var test = Remove("hello\"world\"\"yeah\" test \"fhfh\"");
        return;
    }
