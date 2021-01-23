    public class MyViewModel : INavigationAware
    {
        //[...]
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            Refresh();
        }
        public async void Refresh()
        {
            await Task.Run(() => 
            {
               // Asynchronous work
            }).ContinueWith(t=> /* Actions on Gui Thread */, TaskScheduler.FromCurrentSynchronizationContext());            
        }
        //[...]
    }
