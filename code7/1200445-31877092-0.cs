    public static void DescribeType<T>(T element)
    {
      Console.WriteLine(typeof(T).FullName);
    }
    public static void Main()
    {
      DescribeType(42);               // System.Int32
      DescribeType(42L);              // System.Int64
      DescribeType(DateTime.UtcNow);  // System.DateTime
    }
