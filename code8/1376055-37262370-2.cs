    public class CategoryPage {
        private IWebDriver driver;
        [FindsBy(How = How.CssSelector, Using = ".notFound")]
        private IWebElement products;
        public CategoryPage(IWebDriver webDriver) {
            driver = webDriver;
        }
        public bool IsProductList {
            get {
                try {
                    return products.Equals(products);
                } catch (NoSuchElementException) {
                    return false;
                }
            }
        }
        // other stuff
    }
