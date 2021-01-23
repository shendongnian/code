    // check and remove duplicates
    for (int x = 0; x < message.To.Count; x++)
    {
        for (int y = message.To.Count - 1; y > x; y--)
        {
            if (message.To[y].Address == message.To[x].Address)
                message.To.RemoveAt(y);
        }
        for (int y = message.CC.Count - 1; y >= 0; y--)
        {
            if (message.CC[y].Address == message.To[x].Address)
                message.CC.RemoveAt(y);
        }
        for (int y = message.Bcc.Count - 1; y >= 0; y--)
        {
            if (message.Bcc[y].Address == message.To[x].Address)
                message.Bcc.RemoveAt(y);
        }
    }
    for (int x = 0; x < message.CC.Count; x++)
    {
        for (int y = message.CC.Count - 1; y > x; y--)
        {
            if (message.CC[y].Address == message.CC[x].Address)
                message.CC.RemoveAt(y);
        }
        for (int y = message.Bcc.Count - 1; y >= 0; y--)
        {
            if (message.Bcc[y].Address == message.CC[x].Address)
                message.Bcc.RemoveAt(y);
        }
    }
    for (int x = 0; x < message.Bcc.Count; x++)
    {
        for (int y = message.Bcc.Count - 1; y > x; y--)
        {
            if (message.Bcc[y].Address == message.Bcc[x].Address)
                message.Bcc.RemoveAt(y);
        }
    }
