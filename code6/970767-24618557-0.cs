    public class MyView
    {
       public MyView()
       {
          InitializeComponent();
          Messenger.Default.Register<NotificationMessage>(this, msg =>
          {
             if ((msg.Sender == this.DataContext) && (msg.Notification.ToUpper() == "CLOSE"))
                this.Close();
          });
       }
    }
