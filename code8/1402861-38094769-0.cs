    private async void button1_Click(object sender, EventArgs e)
    {
        try
        {
            await Task1(cts.Token);
            await Task2(cts.Token);
        }
        catch (TaskCancelledException ex)
        {
        }
    }
    private async Task Task1(CancellationToken token)
    {
        while (true)
        {
            token.ThrowIfCancellationRequested();
            await Task.Delay(500, token); // pass token to ensure delay canceled exactly when cancel is pressed
            ChangeParameter(0);
            await Task.Delay(1000, token);
            ChangeParameter(10);
            await Task.Delay(500, token);
            ChangeParameter(0);
        }
    }
    private async Task Task2(CancellationToken token)
    {
        while (true)
        {
            token.ThrowIfCancellationRequested();
            await Task.Delay(100, token);
            int data = await Task.Run(() => GetDataFromDevice()); //assuming this could be long running operation it shouldn't be on ui thread
            UpdateTextBoxWithData(data);
        }
    }
