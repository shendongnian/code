    Transaction myTransaction = new Transaction();
    string[] data = Console.ReadLine().Split(',');
    while (data[0] != "#")
    {
        myTransaction.Name = data[0];
        Double.TryParse(data[1], out myTransaction.Cost); //<-- this is the issue
        Int32.TryParse(data[2], out myTransaction.Quantity); //<-- here again
        Console.WriteLine(myTransaction);
        data = Console.ReadLine().Split(',');
    }
