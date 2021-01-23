    public class LoginVM : INotifyPropertyChanged
    {
        public LoginVM(EventHandler<string> passwordSetHandler)
        {
            if (passwordSetHandler != null)
            {
                PasswordSet += passwordSetHandler;
            }
            PopulateLatestServer();
        }
        //  If the consumer doesn't want to handle it right way, don't force the issue.
        public LoginVM()
        {
            PopulateLatestServer();
        }
