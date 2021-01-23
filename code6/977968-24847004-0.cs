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
    // other properties
    IMainUI _mainUi;
    
    public IRC(IMainUI mainUi)
    {
     this._mainUi = mainUi;
    
    // Other constructor stuff.
    }
    
    // Other logic.
    }
