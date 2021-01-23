    Transaction myTransaction = new Transaction();
    string[] data = Console.ReadLine().Split(',');
    while (data[0] != "#")
    {
        myTransaction.Name = data[0];
    
        double dCost;
        int dQty;
    
        Double.TryParse(data[1], out dCost); //<-- this is hte issue
        Int32.TryParse(data[2], out dQty); //<-- here again
        myTransaction.Cost = dCost;
        myTransaction.Quantity = dQty;
        Console.WriteLine(myTransaction);
        data = Console.ReadLine().Split(',');
    }
