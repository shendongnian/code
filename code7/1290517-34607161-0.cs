    public static class Utils
    {
        public static Task WhenMouseUp(this Control control)
        {
            var tcs = new TaskCompletionSource<object>();
            MouseEventHandler onMouseUp = null;
            onMouseUp = (sender, e) =>
            {
                control.MouseUp -= onMouseUp;
                tcs.TrySetResult(null);
            };
            control.MouseUp += onMouseUp;
            return tcs.Task;
        }
    }
