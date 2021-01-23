    public async Task TaskRun(CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();
        SpeechSynthesizer _speechSynthesizer = new SpeechSynthesizer();
        using (ct.Register(() => _speechSynthesizer.SpeakAsyncCancelAll())) {
            await _speechSynthesizer.SpeakAsync("This is a test prompt");
        }
    }
