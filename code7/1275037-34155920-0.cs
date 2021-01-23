    public class Logger : ILogger
    {
        public void outputMessage(string message)
        {
            Console.WriteLine(message);
        }
    
        public void outputUserMessage(string message)
        {
            MessageBox.Show(message);
        }
    
        public async Task outputMetroUserMessage(object window, String title, String message)
        {
            MetroWindow mWindow = (MetroWindow)window;
            await mWindow.ShowMessageAsync(title, message);
        }
    
        public async Task outputMetroUserMessageWithHidingMDI(object window, string title, string message)
        {
            UIGlobals.MainPageMdiChild.Visibility = Visibility.Hidden;
            MetroWindow mWindow = (MetroWindow)window;
            await mWindow.ShowMessageAsync(title, message);
            UIGlobals.MainPageMdiChild.Visibility = Visibility.Visible;
        }
    }
