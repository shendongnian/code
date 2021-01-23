    public class LoginViewModel : BindableBase, IInteractionRequestAware
    {
        public Action FinishInteraction { get; set; }
        private INotification notification;
        public INotification Notification
        {
            get { return this.notification; }
            set { SetProperty(ref notification, value); }
        }
    }
