    public class MainViewModel: Screen
    {
        public MainViewModel()
        {
            Task.Run(() =>
            {
                while (!ConnectServer())
                {
                    Console.WriteLine("Connection failed");
                    return;
                }
         
                // Following method can only be run if server connection established
                Dispatcher.BeginInvoke(ProcessThis);
            }
        }
    }
