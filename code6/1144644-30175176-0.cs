    foreach(Message m in messages)
            {
                Message m2 = service.Users.Messages.Get("me", m.Id).Execute();
                Console.WriteLine("Message: {0}", m2.Snippet);
            }
