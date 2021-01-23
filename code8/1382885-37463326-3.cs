    private const string MessageAddress = @".\Private$\MyProgram";
            using (var msmq = new MessageQueue(MessageAddress))
                msmq.Send(new MyMessage
                {
                    Command = command,
                    EntityID = id
                });
            
