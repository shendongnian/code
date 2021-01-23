    public class PopupResult
        : IViewModel
    {
        //Some code
    }
    public class ActivityRunner
    {
        public Task<PopupResult> Do<Popup>()
        {
            var tcs = new TaskCompletionSource<PopupResult>();
            var view = new Popup();
            var model = new PopupResult();
            view.DataContext = model;
            view.Close += (e, o) => tcs.SetResult(model);
            return tcs.Task;
        }
    }
    
    
    async void ShowPopupThenDoSomething()
    {
        PopupResult result = await ActivityRunner.Do<Popup>();
        //Do something when we close
    }
