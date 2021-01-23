    int messageCount = client.GetMessageCount();
    
    for(int i = 1; i <= messageCount; i++)
    {
        if (client.GetMessageHeaders(i).Subject != "my_secret_subject")
        {
            client.DeleteMessage(i);
        }
    }
