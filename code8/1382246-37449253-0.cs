    private static void Main(string[] args)
    {
        var epoch = new DateTime(1904, 01, 01, 0, 0, 0, DateTimeKind.Utc);
        var offset = TimeSpan.FromHours(6);
        // How many seconds between 1904/01/01 and 1973/01/01?
        var timestamp1973 = (new DateTime(1973, 01, 01, 0, 0, 0, DateTimeKind.Local) - epoch).TotalSeconds;
        Console.WriteLine("1973 timestamp = {0:N0}", timestamp1973);
        Console.WriteLine("Verify calculation: {0}", epoch.AddSeconds(timestamp1973));
        // How many seconds is that different from int.MaxValue?
        var overflow = timestamp1973 - int.MaxValue;
        Console.WriteLine("Overflow = {0:N0}", overflow);
        // So take int.MaxValue and add the overflow
        var wrongTimeStamp = int.MaxValue;
        wrongTimeStamp += (int) overflow;
        Console.WriteLine("wrong time stamp = {0:N0}", wrongTimeStamp);
        // And the calculation with that value is:
        Console.WriteLine("Wrong date = {0}", epoch.AddSeconds(wrongTimeStamp));
        Console.ReadLine();
    }
