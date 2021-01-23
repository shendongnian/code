    public class Null { private Null() { } }
        public static class ContentDialogExtensions
        {
            public static async Task<ContentDialogResult> EnqueueAndShowIfAsync(this ContentDialog contentDialog, Func<int> predicate = null)
            {
                TaskCompletionSource<Null> currentDialogCompletion = new TaskCompletionSource<Null>();
    
                // No locking needed since we are always on the UI thread.
                if (!CoreApplication.MainView.CoreWindow.Dispatcher.HasThreadAccess) { throw new NotSupportedException("Can only show dialog from UI thread."); }
                var previousDialogCompletion = _previousDialogCompletion;
                _previousDialogCompletion = currentDialogCompletion;
    
                if (previousDialogCompletion != null)
                {
                    await previousDialogCompletion.Task;
                }
                var whichButtonWasPressed = ContentDialogResult.None;
                if (predicate == null || predicate() <=1)
                {
                    whichButtonWasPressed = await contentDialog.ShowAsync();
                }
                currentDialogCompletion.SetResult(null);
                return whichButtonWasPressed;
            }
    
            private static TaskCompletionSource<Null> _previousDialogCompletion;
        }
