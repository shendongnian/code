    public static byte[] Add(byte[] a, byte[] b, int index = -1)
    {
		if (index < 0)
		{
			return Add((byte[])a.Clone(), b, 0);
		}
        if (index < a.Length)
        {
            Add(a, b, index + 1);
            a[index] += b[index];
        }
		return a;
    }
    static public void Main(string[] args)
    {
        var r1 = Add(new byte[] { 1, 1, 1 }, new byte[] { 1, 1, 1 });
        var r2 = Add(new byte[] { 1, 1, 255 }, new byte[] { 0, 0, 1 });
        var r3 = Add(new byte[] { 0, 100, 200 }, new byte[] { 3, 2, 1 });
        // Outputs: 2, 2, 2
        Console.WriteLine(string.Join(", ", r1.Select(n => "" + n).ToArray()));
        // Outputs: 1, 1, 0
        Console.WriteLine(string.Join(", ", r2.Select(n => "" + n).ToArray()));
        // Outputs: 3, 102, 201
        Console.WriteLine(string.Join(", ", r3.Select(n => "" + n).ToArray()));
    }
