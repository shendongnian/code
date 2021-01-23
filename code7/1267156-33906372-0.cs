    Task.Run(() =>
    {
        using (var client = new QueueMessageClient())
        {
            do
            {
                var result = client.GetMessages();
                // Do something with the resulting messages
                Parallel.ForEach(result.Messages, message =>
                {
                });
            } while (true);
        }
    });
