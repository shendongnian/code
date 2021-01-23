    public partial class App : Application
    {
        protected override async void OnStartup(StartupEventArgs e)
        {
            Func<Task> a = async () =>
            {
                while (true)
                {
                    Trace.WriteLine("A ->");
                    await Task.Delay(TimeSpan.FromSeconds(0.1));
                    Trace.WriteLine("-> A");
                }
            };
            Func<Task> b = async () =>
            {
                while (true)
                {
                    Trace.WriteLine("B ->");
                    await Task.Delay(TimeSpan.FromSeconds(0.09));
                    Trace.WriteLine("-> B");
                }
            };
            await Task.WhenAll(a(), b());
            base.OnStartup(e);
        }
    }
