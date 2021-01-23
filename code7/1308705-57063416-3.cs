    public class LoginPage : BasePage, ILoad
    {
        [XPath("//*[@class = 'linkButtonFixedHeader office-signIn']")] private Button SignIn;
        [XPath("//input[@type = 'email']")] private TextInputField Email;
        [XPath("//input[@type = 'submit']")] private Button Submit;
        [XPath("//input[@type = 'password']")] private TextInputField Password;
        public LoginPage() : base(new BaseDriver(), "https://outlook.live.com/")
        {
        }
        public bool IsLoaded() =>
            SignIn.IsVisible() &&
            Email.IsVisible() &&
            Submit.IsVisible();
        public MainMailPage PositiveLogin(User user)
        {
            SignIn.Click();
            Email.SendString(user.Login);
            Submit.Click();
            Password.SendString(user.Pass);
            Submit.Click();
            return Page<MainMailPage>();
        }
    }
