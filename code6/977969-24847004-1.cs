    public interface IMainUI
    {
        void AddText(string text, Color color);
        void UiThread(Action code);
    }
    
    public class MainUI : IMainUI
    {
         // Whatever else
        public void AddText(string text, Color color)
        {
            UiThread( () => 
            {
               // Same code that was in your Irc.SendToChatBox method.     
            });
        }
    
        public void UiThread(Action code)
        {
            if (InvokeRequired)
            {
                BeginInvoke(code);
                return;
            }
            code.Invoke();
        }
    }
    
    public class IRC
    {
        IMainUI _mainUi;
        //Other properties, and fields    
        public IRC(IMainUI mainUi)
        {
            this._mainUi = mainUi;
    
            // Other constructor stuff.
        }
    
        // Other logic and methods
    }
