    public class MainViewModel: Screen
    {
        public MainViewModel()
        {
            Task.Run(() =>
            {
                while (!ConnectServer())
                {
                    Console.WriteLine("Connection failed");
                    Thread.Sleep(10*1000);
                }
         
                // Following method can only be run if server connection established
                Application.Current.Dispatcher.Invoke(ProcessThis);
            }
        }
    }
