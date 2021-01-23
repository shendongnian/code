    public class MainViewModel: Screen
    {
        public MainViewModel()
        {
            Initialize();
        }
    }
    
    private async void Initialize()
    {
            await Task.Run(() =>
            {
                while (!ConnectServer())
                {
                    Console.WriteLine("Connection failed");
                    return;
                }
            }
    
            // Following method can only be run if server connection established
            ProcessThis();
    }
