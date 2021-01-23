    using System.IdentityModel.Selectors;
    namespace MyNameSpace.Web
    {
    public class UserValidator : UserNamePasswordValidator
    {
        public UserValidator() : base()
        {
            
        }
        public override void Validate(string username, string password)
        {
        }
    }
    }
