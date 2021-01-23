    using (MessageQueue msMq = GetQueue())
    {
        MessagePump pump = MessagePump.Run(
            msMq,
            async message =>
            {
                await Task.Delay(50);
                Console.WriteLine($"Finished processing message {message.Id}");
            },
            maxDegreeOfParallelism: 4
        );
        for (int i = 0; i < 100; i++)
        {
            msMq.Send(new Message());
            Thread.Sleep(25);
        }
        pump.Stop();
        await pump.Completion;
    }
