    Task.Factory.StartNew(() =>
        {
            if (message.Delay != null)
            {
                foreach (var plane in message.Planes)
                {
                    AddPins(new[] {plane});
                    Thread.Sleep(message.Delay.Value);
                }
            }
        });
