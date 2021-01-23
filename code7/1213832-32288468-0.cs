    public class MailController : MailerBase
    {
        public async Task CreateUserAsync(ViewModel.VM_User user)
        {
            To.Add(user.EmailAddress);
            From = System.Configuration.ConfigurationManager.AppSettings["emailSender"];
            Subject = "Hi";
            await (Email("CreateUser", user).DeliverAsync());
        }
    }
