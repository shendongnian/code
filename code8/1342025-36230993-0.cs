    static void Main(string[] args)
    {
        string[] instances1 = { "i-xxxxx01", "i-xxxxx02" };
        AWSAccount account1 = new AWSAccount("53853288254", instances1);
        Console.WriteLine("AWS Account Id = {0} Instances = {1} {2}", account1.AccountId, account1.Instances[0], account1.Instances[1]);
        string[] instances2 = { "i-zzzzz01", "i-zzzzz02" };
        AWSAccount account2 = new AWSAccount("74378834238", instances2);
        Console.WriteLine("AWS Account Id = {0} Instances = {1} {2}", account2.AccountId, account2.Instances[0], account2.Instances[1]);
        AWSAccount[] array1 = new AWSAccount[2];
        array1[0] = account1;
        array1[1] = account2;
        Console.WriteLine("AWS Account Id = {0}", array1[0].AccountId);
        Console.WriteLine("AWS Account Id = {0}", array1[1].AccountId);
        // Keep the console open in debug mode.
        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }
