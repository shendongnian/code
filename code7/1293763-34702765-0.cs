    public abstract class AbstractPage
    {
        protected AbstractPage()
        {
            WaitUntilExist();
        }
        protected abstract void WaitUntilExist();
    }
    public class MyPage : AbstractPage
    {
        [FindsBy(How = How.Id, Using = "SomeID")]
        private IWebElement SearchButton;
        public MyPage()
        {
        }
        
        protected override void WaitUntilExist()
        {
            wait.Until(ExpectedConditions.ElementExists(By.Id("SomeID")));
        }
    }
