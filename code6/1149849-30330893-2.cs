    private static void Team1Shots()
    {
        foreach(var message in thread1Messages.GetConsumingEnumerable())
        {
            WorkerStateMessage nextMessage;
            switch(message.Type)
            {
                case MessageType.Work1:
                    var added = message.Data + 1;
                    nextMessage = new WorkerStateMessage
                    {
                        Type = MessageType.Work2, 
                        Progress = "Add 1",
                        Data = added
                    };
                    progressMessages.Add(nextMessage);
                    thread2Messages.Add(nextMessage);
                break;
                case MessageType.Work3:
                    var multiplied = message.Data + 1;
                    nextMessage = new WorkerStateMessage
                    {
                        Type = MessageType.Work4,
                        Progress = "Multiply by 2",
                        Data = multiplied
                    };
                    progressMessages.Add(nextMessage);
                    thread2Messages.Add(nextMessage);
                break;
                default:
                    return;
            }
        }
    }
