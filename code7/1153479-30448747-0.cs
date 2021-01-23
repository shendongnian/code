    string name = clientList[index].ClientName;
    foreach(var client in clientList)
    {
        name = client.ClientName; // access the item one by one
    }
