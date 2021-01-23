    // there is no non-generic TaskCompletionSource, so use bool
    private TaskCompletionSource<bool> installationCompletion
        = new TaskCompletionSource<bool>();
    public Task InstallationCompletion { get { return installationCompletion.Task; } }
    public async Task InstallAsync()
    {
        await Task.WhenAll(this.Dependencies.Select(c => c.InstallationCompletion));
        // install this component here
        installationCompletion.SetResult(true);
    }
