    static public class ContentDialogExtensions
    {
        static public async Task<ContentDialogResult> EnqueueAndShowIfAsync( this ContentDialog contentDialog, Func<bool> predicate = null)
        {
            TaskCompletionSource<Null> currentDialogCompletion = new TaskCompletionSource<Null>();
            TaskCompletionSource<Null> previousDialogCompletion = null;
            // No locking needed since we are always on the UI thread.
            if (!CoreApplication.MainView.CoreWindow.Dispatcher.HasThreadAccess) { throw new NotSupportedException("Can only show dialog from UI thread."); }
            previousDialogCompletion = ContentDialogExtensions.PreviousDialogCompletion;
            ContentDialogExtensions.PreviousDialogCompletion = currentDialogCompletion;
            if (previousDialogCompletion != null) {
                await previousDialogCompletion.Task;
            }
            var whichButtonWasPressed = ContentDialogResult.None;
            if (predicate == null || predicate()) {
                whichButtonWasPressed = await contentDialog.ShowAsync();
            }
            currentDialogCompletion.SetResult(null);
            return whichButtonWasPressed;
        }
        static private TaskCompletionSource<Null> PreviousDialogCompletion = null;
    }
