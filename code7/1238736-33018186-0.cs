    PrintServer printServer = new PrintServer();
    PrintQueue printQueue = printServer.GetPrintQueue("HP USB");
    foreach (PropertyInfo property in printQueue.GetType().GetProperties())
    {
        Console.WriteLine(property.Name + " : " + property.GetValue(printQueue));
    }
