    public class UserManager : IEventHandler<CustomerDeleted>
    {
        public UserManager(IUserRepository repos, IEventPublisher publisher)
        {
        }
    
        public void Handle(CustomerDeleted evt)
        {
            var users = _repos.FindUsersForCustomer(evt.CustomerId);
            foreach (var user in users)
            {
                _repos.Delete(user);
                _publisher.Publish(new UserDeleted(user.Id, user.CustomerId));
            }
        }
    }
