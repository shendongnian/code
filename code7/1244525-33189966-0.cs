    for (int i = 0; i < clients.Count; i++)
    {
        if (!regex.IsMatch(clients[i].Phone))
             clients[i].Phone = "[Netinkama ivestis]";
        }
    }
