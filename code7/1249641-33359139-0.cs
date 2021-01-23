    while ((rLine = sReader.ReadLine()) != null) {
        string text = rLine.Remove(rLine.IndexOf('|') - 1);  //message | response
        string response = rLine.Remove(0, rLine.IndexOf('|') + 2) ;
        string realText = text.ToLower();
    
        if (callback.Message.Contains(realText) || callback.Message.Contains(text))
        {
            steamFriends.SendChatMessage(callback.Sender, EChatEntryType.ChatMsg, response);
            Console.WriteLine("Someone has messaged me, and I replied with an automated message.");
            sReader.Close();
            return;
        }
    }
    
    steamFriends.SendChatMessage(callback.Sender, EChatEntryType.ChatMsg, "I don't know what you mean. Could you maybe write it a bit differently? <3");
    Console.WriteLine("Someone has messaged me, and it    wasn't on my auto-response list: {0}",callback.Message);
    sReader.Close();
    return;
