     public partial class Dossier : Window
    {
        
        public Dossier()
        {
            
            InitializeComponent();
            Messenger.Default.Register<ExitMessage>(this, "DossierFinancement", (action) => CloseWindow(action));
            Messenger.Default.Register<ExceptionMessageRefresh>(this, "DossierFinancement", (action) => ShowExceptionMessage(action));
            Messenger.Default.Register<NotificationMessage>(this, "DossierFinancementInfo", (action) => ProcessNotification(action));
            Messenger.Default.Register<NotificationMessage>(this, "DossierFinancementError", (action) => ProcessErrorDialogNotification(action));
            }
        private void ProcessNotification(NotificationMessage action)
        {
            MessageBox.Show(action.Notification.ToString(), "Information", MessageBoxButton.OK,MessageBoxImage.Information);
        }
        private void ProcessErrorDialogNotification(NotificationMessage action)
        {
            MessageBox.Show(action.Notification.ToString(), "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
        }
      
        private void CloseWindow(ExitMessage action)
        {
            this.Close();
            Messenger.Default.Unregister<ExitMessage>(this, "DossierFinancement");
        }
        private void ShowExceptionMessage(ExceptionMessageRefresh obj)
        {
      //Without the following Call of Dispatcher, An exception "Thread must be STA... will be fired         
       Dispatcher.BeginInvoke(new Action(() =>
            {
                UICommon.ShowErrorMessage(obj.ExceptionToRefresh);
            }));
        }
        
    }
