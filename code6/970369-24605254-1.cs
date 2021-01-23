    using System.ServiceProcess;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace WindowsService1
    {
        public partial class Service1 : ServiceBase
        {
            CancellationTokenSource _mainCts;
            Task _mainTask;
    
            public Service1()
            {
                InitializeComponent();
            }
    
            async Task MainTaskAsync(CancellationToken token)
            {
                while (true)
                {
                    token.ThrowIfCancellationRequested();
                    // ... 
                    await DoPollingAsync(token);
                    // ... 
                }
            }
    
            protected override void OnStart(string[] args)
            {
                _mainCts = new CancellationTokenSource();
                _mainTask = MainTaskAsync(_mainCts.Token);
            }
    
            protected override void OnStop()
            {
                _mainCts.Cancel();
                try
                {
                    _mainTask.Wait();
                }
                catch
                {
                    if (!_mainTask.IsCanceled)
                        throw;
                }
            }
        }
    }
