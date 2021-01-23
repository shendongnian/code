    private static void Team2Shots()
    {
       foreach(var message in thread2Messages.GetConsumingEnumerable())
        {
            WorkerStateMessage nextMessage;
            switch(message.Type)
            {
                case MessageType.Work2:
                    var added = message.Data + 2;
                    nextMessage = new WorkerStateMessage
                    {
                        Type = MessageType.Work3,
                        Progress = "Add 2",
                        Data = added
                    };
                    progressMessages.Add(nextMessage);
                    thread1Messages.Add(nextMessage);
                break;
                case MessageType.Work4:
                    var divided = message.Data / 2;
                    nextMessage = new WorkerStateMessage 
                    {
                        Type = MessageType.Work3,
                        Progress = "Divide by 2",
                        Data = divided
                    };
                    progressMessages.Add(nextMessage);
                    thread2Messages.Add(nextMessage);
                break;
                default:
                    return;
            }
        }
    }
