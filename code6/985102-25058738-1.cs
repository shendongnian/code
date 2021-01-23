        [TestCase("www.googel.com")]
        public bool TestAllWebpageLinks(string url, Result = true)
        {
            _driver.Navigate().GoToUrl(url);
            var result = _driver.FindElements(By.TagName("a"))
                .Select(o=>o.GetAttribute("href"))
                .ToDictionary(o=>o,o=>TestPage(url,o));
            return result.All(o => o.Value);
        }
        public bool TestPage(string url, string link){
            try
            {
                _driver.Navigate().GoToUrl(url);
                _driver.FindElement(By.XPath("//a[@href='"+link+"']")).Click();     
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
