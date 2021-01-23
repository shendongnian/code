    public class Activity
    {
        public Task<Result> PopupActivity()
        {
            var tcs = new TaskCompletionSource<Result>();
            var popup = new Popup();
            popup.Show();
            popup.Close += (e, o) => tcs.SetResult(popup.DataContext);
            return tcs.Task;
        }
    }
    
    
    async void ShowPopupThenDoSomething()
    {
        var result = await Activity.PopupActivity()
        //Do something when we close
    }
