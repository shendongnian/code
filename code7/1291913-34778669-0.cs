    using DotNetNuke.Entities.Users;
    [Export(typeof(IUserEventHandlers))]
    public class MyUserEventHandlers : IUserEventHandlers
    {
        public void UserAuthenticated(object sender, UserEventArgs args)
        {
            SisterSiteLibrary.CreateUserOnSisterSite(args.User);
        }
        public void UserCreated(object sender, UserEventArgs args)
        {
        }
        public void UserDeleted(object sender, UserEventArgs args)
        {
        }
        public void UserRemoved(object sender, UserEventArgs args)
        {
        }
        public void UserApproved(object sender, UserEventArgs args)
        {
        }
    }
