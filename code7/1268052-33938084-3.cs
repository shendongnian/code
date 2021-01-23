    public class AssignUserViewModel 
    {
        private readonly IMessageService messageService;
        private readonly IUserRepository users;
        public AssignUserViewModel(IMessageService messageService, IUserRepository userRepository) 
        {
            if(messageService == null) 
            {
                throw new ArgumentNullException("messageService");
            }
            if(userRepository == null) 
            {
                throw new ArgumentNullException("userRepository");
            }
            this.messageService = messageService;
            this.users = userRepository;
            // register to the AssingUserMessage here
            this.messageService.Register<AssignUserMessage>(OnAssignUserMessage);
        }
        private void OnAssignUser(AssignUserMessage message)
        {
            var user = await users.GetByUserIdAsync(message.UserId);
            // display your user and whatever you want to assign it and once done, 
            // save the changes, then send a notification that the user has been updated
            this.messageService.Send<UserAssignedMessage>(
                new UserAssignedMessage() 
                {
                    UserId = user.Id
                }
            );
        }
    }
