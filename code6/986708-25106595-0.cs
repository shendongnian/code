    private static void OnContinuationAction(Task<string> text)
    {
        Console.WriteLine(text);
        ReceiveDataAsync().ContinueWith(OnContinuationAction);
    }
    ...
    ReceiveDataAsync().ContinueWith(OnContinuationAction);
