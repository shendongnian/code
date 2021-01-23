    public class LoginPage : BasePage, ILoad
    {
        [FindsBy(How = How.XPath, Using = "//*[@class = 'linkButtonFixedHeader office-signIn']")] private Button SignIn;
        [FindsBy(How = How.XPath, Using = "//input[@type = 'email']")] private TextInputField Email;
        [FindsBy(How = How.XPath, Using = "//input[@type = 'submit']")] private Button Submit;
        [FindsBy(How = How.XPath, Using = "//input[@type = 'password']")] private TextInputField Password;
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
