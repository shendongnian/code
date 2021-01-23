    // first until second last element
    int secondLastIndex = listClientCallBacks.Count - 2;
    for (int index = 0; index <= secondLastIndex; index++)
    {
        IClientCallBack client = listClientCallBacks[index];
        client.Enter(name);
    }
    
    // last element
    if (listClientCallBacks.Count > 0)
    {
        IClientCallBack lastClient = listClientCallBacks.Last();
        foreach (var n in listClientsName)
        {
            lastClient.Enter(n);
        }
        return;
    }
