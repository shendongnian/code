    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver browser = new FirefoxDriver();
            List<IWebElement> result = new List<IWebElement>();
            IList<IWebElement> tableRows = browser.FindElements(By.XPath("id('column2')/tbody/tr"));
            By nameLocator = By.ClassName("td > div.name");
            By addressLocator = By.ClassName("td > div.address");
            By sexLocator = By.ClassName("td > div.sex");
            By scoretextLocator = By.ClassName("td > div.score_text");
            // String.Format Method https://msdn.microsoft.com/en-us/library/aa331875(v=vs.71).aspx
            Console.WriteLine("{0,10}{1,10}{2,10}{3,10}",  "Name",  "Address",  "Sex",  "Score");
            foreach (IWebElement rows in tableRows)
            {
                Values values = new Values();
                values.name = rows.FindElement(nameLocator).Text.Trim();
                values.address = rows.FindElement(addressLocator).Text.Trim();
                values.sex = rows.FindElement(sexLocator).Text.Trim();
                values.scoretext = rows.FindElement(scoretextLocator).Text.Trim();
                Console.WriteLine("{0,10}{1,10}{2,10}{3,10}", values.name, values.address, values.sex, values.scoretext);
            }
        }
    }
    class Values
    {
        public string name;
        public string address;
        public string sex;
        public string scoretext;
        public Values()
        {
            this.name = "";
            this.address = "";
            this.sex = "";
            this.scoretext = "";
        }
    }
