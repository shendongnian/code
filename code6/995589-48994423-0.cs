    private async Task ReadData(CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        DataReaderObject.InputStreamOptions = InputStreamOptions.Partial;
        uint data = 0;
        uint bufferLength = DataReaderObject.UnconsumedBufferLength;
        var timeoutSource = new CancellationTokenSource(100); // 100 ms
        try
        {
            while (true)
            {
                data = await DataReaderObject.LoadAsync(1).AsTask(timeoutSource.Token);
                if (data > 0)
                {
                    String temp = DataReaderObject.ReadString(data);
                    TemperatureValue.Text += temp.Trim();
                }
            }
        }
        catch (Exception)
        {
            ;
        }
    }
