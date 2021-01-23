    public override void OnBackPressed()
    {
        RunOnUiThread(
            async () =>
            {
                var isCloseApp = await AlertAsync(this, "NameOfApp", "Do you want to close this app?", "Yes", "No");
                if (isCloseApp)
                {
                    var activity = (Activity)Forms.Context;
                    activity.FinishAffinity();
                }
            });
    }
    public Task<bool> AlertAsync(Context context, string title, string message, string positiveButton, string negativeButton)
    {
        var tcs = new TaskCompletionSource<bool>();
        using (var db = new AlertDialog.Builder(context))
        {
            db.SetTitle(title);
            db.SetMessage(message);
            db.SetPositiveButton(positiveButton, (sender, args) => { tcs.TrySetResult(true); });
            db.SetNegativeButton(negativeButton, (sender, args) => { tcs.TrySetResult(false); });
            db.Show();
        }
        return tcs.Task;
    }
