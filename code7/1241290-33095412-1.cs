    public class ViewModel
    {
        public ICommand DoSomethingCommand { get; set; }
        public ViewModel()
        {
            DoSomethingCommand = new RelayCommand(DoSomething);
        }
        private async void DoSomething()
        {
            await DownloadStuffAsync();
            Debug.WriteLine("Button Call Completed");
        }
        public async Task DownloadStuffAsync()
        {
            Debug.WriteLine("Start GetStringAsync");
            await Task.Run(() =>
            {
                Debug.WriteLine("Thread sleeping");
                Thread.Sleep(5000);
            }).ConfigureAwait(false);
            string page = await new HttpClient().GetStringAsync("http://www.ibm.com").ConfigureAwait(false);
            Debug.WriteLine("End GetStringAsync");
        }
    }
