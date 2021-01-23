    public static IEnumerable<String> loop()
    {
        char[] chars = new char[] { 'a', 'b', 'c' };
        for (int i = 0; i < 3000; i++)
        {
            string s = string.Format("aa{0}aa{1}a{2}{3}", (i % 1000) / 100, (i % 100) / 10, chars[(i % 10000) / 1000], i % 10);
            System.Diagnostics.Debug.WriteLine(s);
            yield s;
        }
    }
