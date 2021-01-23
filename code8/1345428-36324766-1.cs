    public Task Method()
    {
        return Task.Factory.StartNew(() =>
        {
            for (int i = 0; i < 100; i++)
            {
                Task.Delay(1000).Wait();
                Debug.WriteLine(i.ToString());
                count = i.ToString();
            }
        });
    }
