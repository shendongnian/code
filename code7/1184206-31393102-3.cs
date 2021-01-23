    for (int i = 0; i < MessageList.Count; i++)
    {
        var message = MessageList[i][0] as ABCMessage;
        if (message?.ABCProperty2 == 5)
        {
            index = i;
            break;
        }
    }
