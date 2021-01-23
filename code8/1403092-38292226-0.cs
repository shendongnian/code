    public class App
    {
         public void InitializeMessengerHooks()
         {
              messenger.Subscribe(typeof(OpenWindowMessage), m => OpenWindow());
         }
    }
    
    public class ViewModel
    {
         public void OpenWindow()
         {
              messenger.Send(new OpenWindowMessage());
         }
    }
