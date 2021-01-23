    var dispatcher = Deployment.Current.Dispatcher;
    var application = Application.Current;
    UIElement rootVisual = null;
    while (rootVisual == null)
    {
        var taskCompletionSource = new TaskCompletionSource<UIElement>();
        dispatcher.BeginInvoke(() =>
            taskCompletionSource.TrySetResult(application.RootVisual));
        rootVisual = await taskCompletionSource.Task;
    }
