            /// <summary>
            /// Could be injected to your UnityContainer as singleton and then accessed by using Container.Resolve
            /// </summary>
        
        public interface IMessageService
        {
            void ShowDialog(string message, MessageBoxButton messageBoxButton);
        }
        
        public class MessageService : IMessageService
        {
            private readonly Dispatcher _dispatcher;
        
            public MessageService()
            {
              if(Application.Current!=null){
                 _dispatcher = Application.Current.Dispatcher;
              }
              else{
                _dispatcher = Dispatcher.CurrentDispatcher;
              }
            }
        
            public void ShowDialog(string message, MessageBoxButton messageBoxButton)
            {
                if (_dispatcher.CheckAccess())
                {
                    Show(message, messageBoxButton);
                }
                else
                {
                    _dispatcher.Invoke(new Action(() => Show(message, messageBoxButton)));
                }
            }
        
            private static void Show(string message, MessageBoxButton messageBoxButton)
            {
                MessageBox.Show(Application.Current.MainWindow, message, "TITLE", messageBoxButton);
            }
        }
