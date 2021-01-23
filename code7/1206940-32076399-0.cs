    var groupedByUserId = table.AsEnumerable().GroupBy(row => row.Field<int>("UserId"));
    foreach(var group in groupedByUserId)
    {
        Console.WriteLine("User Id: {0}", group.Key);
        Console.WriteLine("Address   Phone");
        int rowNum = 0;
        foreach(DataRow row in group)
        {
            Console.WriteLine("{0}- {1}   {2}", ++rowNum, row.Field<string>("Address"), row.Field<string>("Address"));
        }
    }
        
