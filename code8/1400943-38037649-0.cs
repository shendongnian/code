    // Get directly the last one and add the clients name already in the 'session'
    // to this element. I suppose that the last one need to be informed of the
    // clients already in the list.....
    IClientCallBack client in listClientCallBacks.Last();
    foreach (var n in listClientsName)
        client.Enter(n);
    // Now for every client in the session EXCLUDING  the last one 
    // inform them of the new client that has joined your 'session'
    foreach (IClientCallBack client in listClientCallBacks.Take(listClientCallBacks.Length - 2))
        client.Enter(name);
