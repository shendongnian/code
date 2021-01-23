    List<string> list = new List<string>();
    
    foreach (ITerminalServicesSession session in server.GetSessions())
    {
        NTAccount account = session.UserAccount;
        if (account != null)
        {
            list.Add(account.ToString());
        }
    }
    
    foreach (var item in list)
        Console.WriteLine(item);
        
    Console.WriteLine("Count: " + list.Count);
    Thread.Sleep(10000);
