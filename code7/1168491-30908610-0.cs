    TaskCompletionSource<bool> _tcs;
    async Task Foo()
    {
        // stuff
        _tcs = new TaskCompletionSource<bool>();
        await _tcs.Task
        // other stuff
    }
    void ButtonClicked(object sender, EventArgs e)
    {
        _tcs.SetResult(false);
    }
