    public static Task WhenClicked(this Button button)
    {
        var tcs = new TaskCompletionSource<bool>();
        EventHandler handler = null;
        handler = (s, e) =>
        {
            tcs.TrySetResult(true);
            button.Click -= handler;
        };
        button.Click += handler;
        return tcs.Task;
    }
