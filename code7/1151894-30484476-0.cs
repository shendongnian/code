    public class TownCrier
    {
        readonly Timer _timer;
        public TownCrier()
        {
            _timer = new Timer(1000) {AutoReset = true};
            _timer.Elapsed += (sender, eventArgs) => Console.WriteLine("It is {0} and all is well", DateTime.Now);
        }
        public void Start() { _timer.Start(); }
        public void Stop() { _timer.Stop(); }
    }
    
    public class Program
    {
        public static void Main()
        {
            HostFactory.Run(x =>                            
            {
                x.Service<TownCrier>(s =>                   
                {
                   s.ConstructUsing(name=> new TownCrier());
                   s.WhenStarted(tc => tc.Start());         
                   s.WhenStopped(tc => tc.Stop());          
                });
                x.RunAsLocalSystem();                       
    
                x.SetDescription("Sample Topshelf Host");   
                x.SetDisplayName("Stuff");                  
                x.SetServiceName("Stuff");                  
            });                                             
        }
    }
