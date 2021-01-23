    using (Pop3Client client = new Pop3Client())
    {
         client.Connect("pop.gmail.com", 995, true);
         client.Authenticate("signalxxxxxx@gmail.com", "xxxxxxxx", AuthenticationMethod.UsernameAndPassword);
         int messageCount = client.GetMessageCount();
         List<OpenPop.Mime.Message> allMessages = new List<OpenPop.Mime.Message>(messageCount);
         for (int d = messageCount; d > 0; d--)
         {
              allMessages.Add(client.GetMessage(d));
         }
    }
