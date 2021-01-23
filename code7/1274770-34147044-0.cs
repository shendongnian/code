    public class SeleniumPageObject : BaseClass
    {
        public SeleniumPageObjects()
        {
          PageFactory.InitElements(Driver, this);
        }
    }
