    public class CustomViewService : DefaultViewService 
    {
       ...    
        public override Task<Stream> Login(LoginViewModel model, SignInMessage message)
        {
            var customVm = new CustomViewModel { MyProp = "123" };
            return Render(customVm, LoginView);
        }
    }
