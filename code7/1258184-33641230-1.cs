    public static void Main()
    {
        var myDateTime = GetLocalDateTime(33.8323, -117.8803, DateTime.UtcNow);
        Console.WriteLine(myDateTime.ToString());
    }
