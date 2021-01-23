    public static void findUsers()
    {
        ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_Group");
        ObjectQuery finalQuery = query.Where("LocalAccount.Name = @AcctName");
        finalQuery.Parameters.Add(new ObjectParameter("AcctName", "Test"));
        ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, finalQuery);
        var result = searcher.Get();
         foreach (var envVar in result)
        {
            Console.WriteLine("GroupName: {0}", envVar["Name"]);
        }
        Console.ReadLine();
    }
