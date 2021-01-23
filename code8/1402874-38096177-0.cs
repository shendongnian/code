    private async Task Task1()
    {
        await Task.Run(() =>
        {
            while (!cts.IsCancellationRequested)
            {
                Thread.Sleep(500);
                ChangeParameter(0);
                Thread.Sleep(1000);
                ChangeParameter(10);
                Thread.Sleep(500);
                ChangeParameter(0);
            }
        }
    }
