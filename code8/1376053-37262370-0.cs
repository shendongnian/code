    public class CategoryPage {
        private IWebDriver driver;
        [FindsBy(How = How.CssSelector, Using = ".notFound")]
        private IList<IWebElement> products;
        public CategoryPage(IWebDriver webDriver) {
            driver = webDriver;
        }
        public bool IsProductList {
            get {
                return products.Count > 0;
            }
        }
        // other stuff
    }
