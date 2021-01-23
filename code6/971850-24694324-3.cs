    static readonly TaskCompletionSource<UIElement> RootVisualTask = new TaskCompletionSource<UIElement>();
    static void RootVisualLoop()
    {
        Deployment.Current.Dispatcher.BeginInvoke(() =>
        {
            var rootVisual = Application.Current.RootVisual;
            if (rootVisual != null)
                RootVisualTask.TrySetResult(rootVisual);
            else
                RootVisualLoop();
        });
    }
    internal static async Task<UIElement> RootVisual()
    {
        RootVisualLoop();
        return await RootVisualTask.Task;
    }
