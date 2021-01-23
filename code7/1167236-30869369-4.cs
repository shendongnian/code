    public class MainViewModel: Screen
    {
        public MainViewModel()
        {
            Initialize();
        }
    }
    
    private async void Initialize()
    {
            await Task.Run(async () =>
            {
                while (!ConnectServer())
                {
                    Console.WriteLine("Connection failed");
                    await Task.Delay(10*1000);
                }
            }
    
            // Following method can only be run if server connection established
            ProcessThis();
    }
