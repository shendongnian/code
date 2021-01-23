    internal static class CefTaskHelper
    {
        public static Task RunAsync(CefThreadId threadId, Action action)
        {
            if (CefRuntime.CurrentlyOn(threadId))
            {
                action();
                return TaskHelpers.Completed();
            }
            else
            {
                var tcs = new TaskCompletionSource<FakeVoid>();
                StartNew(threadId, () =>
                {
                    try
                    {
                        action();
                        tcs.SetResultAsync(default(FakeVoid));
                    }
                    catch (Exception e)
                    {
                        tcs.SetExceptionAsync(e);
                    }
                });
                return tcs.Task;
            }
        }
        public static void StartNew(CefThreadId threadId, Action action)
        {
            CefRuntime.PostTask(threadId, new CefActionTask(action));
        }
    }
