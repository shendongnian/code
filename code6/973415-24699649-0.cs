    private async Task CheckMeCalled(CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();
        Debug.WriteLine("Before task delayed".ToUpper());
        await Task.Delay(5000);
        Debug.WriteLine("After task delayed".ToUpper());
    }
