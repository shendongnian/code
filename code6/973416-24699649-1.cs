    private async Task CheckMeCalled(CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();
        Debug.WriteLine("Before task delayed".ToUpper());
        await Task.Delay(5000, ct);
        Debug.WriteLine("After task delayed".ToUpper());
    }
