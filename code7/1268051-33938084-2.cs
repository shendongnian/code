    public class MainViewModel 
    {
        private readonly IMessageService messageService;
        public MainViewModel(IMessageService messageService) 
        {
            if(messageService == null) 
            {
                throw new ArgumentNullException("messageService");
            }
            this.messageService = messageService;
        }
        private void AssignUser(int userId)
        {
            this.messageService.Send<AssignUserMessage>(
                new AssignUserMessage() 
                {
                    UserId = userId
                }
            );
        }
    }
