    using (var mqClient = mqServer.CreateMessageQueueClient())
    {
        mqClient.Publish(new Message<HelloIntro>(new Hello { Name = "World" }) {
            Meta = new Dictionary<string, string> { { "Custom", "Header" } }
        });
    }
