    private async void button1_Click(object sender, EventArgs e)
    {
        var progress=new Progress<int>(data=>UpdateTextBoxWithData(data));
        //...
        //Allow for cancellation of the task itself
        var token=cts.Token;
        await Task.Run(()=>MeasureInBackground(token,progress),token);
    }
    private async Task MeasureInBackground(CancellationToken token,IProgress<int> progress)
    {
        while (!token.IsCancellationRequested)
        {
            await Task.Delay(100,token);
            int data = GetDataFromDevice(); 
            progress.Report(data);
        }
    }
