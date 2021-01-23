    for (int i = 0; i < MessageList.Count; i++) 
    {
        var message = MessageList[i][0] as ABCMessage;
        if (MessageList[i][0] is ABCMessage && (ABCMessage)MessageList[i][0].ABCProperty2 == 5) 
        {
            index = i;
            break;
        }
    }
