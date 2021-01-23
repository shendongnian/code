    public static List<char[]> Split(char[] source, int keysize)
    {
        List<char[]> list = new List<char[]>();
        for (int i = 0; i < source.Length; i+= keysize)
        {
            List<char> c = source.Skip(i).Take(keysize).ToList();
            while (c.Count < keysize)
            {
                c.Add('|');
            }
            list.Add(c.ToArray());
        }
        return list;
    }
    static void Main(string[] args)
    {
        var x = Split("abcdefgh".ToCharArray(), 3);
        Console.ReadLine();
    }
