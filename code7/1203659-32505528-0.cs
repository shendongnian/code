    using System;
    using FluentAutomation;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    namespace HelloWorldTests
    {
        [TestClass]
        public class WithPageObjectTests : FluentTest
        {
            public WithPageObjectTests()
            {
                SeleniumWebDriver
                    .Bootstrap(SeleniumWebDriver.Browser.InternetExplorer);
            }
    
            [TestInitialize]
            public void TestInitialisze()
            {
                // Global wait timer
                Config.Settings.WaitUntilTimeout = TimeSpan.FromSeconds(5);
                
                Config.Settings.ScreenshotOnFailedAction = true;
                Config.Settings.ScreenshotOnFailedAssert = true;
                Config.Settings.ScreenshotOnFailedExpect = true;
            }
    
            [TestMethod]
            public void SearchForFluentAutomation()
            {
                new BingSearchPage(this)
                    .Go()
                    .Search("FluentAutomation")
                    .FindResultUrl("http://fluent.stirno.com/blog/FluentAutomation-scriptcs/");
            }
        }
    
        /// <summary>
        /// Page model
        /// </summary>
        public class BingSearchPage : PageObject<BingSearchPage>
        {
            //private const string SearchInput = "input[title='Enter your search term']";
            private const string SearchInput = "#sb_form_q";
    
            public BingSearchPage(FluentTest test)
                : base(test)
            {
                Url = "http://bing.com/";
                At = () => I.Expect.Exists(SearchInput);
            }
    
            public BingSearchResultsPage Search(string searchText)
            {
                I.Enter(searchText).In(SearchInput);
                I.Press("{ENTER}");
                return this.Switch<BingSearchResultsPage>();
            }
        }
    
        /// <summary>
        /// Page model
        /// </summary>
        public class BingSearchResultsPage : PageObject<BingSearchResultsPage>
        {
            private const string SearchResultsContainer = "#b_results";
            private const string ResultUrlLink = "a[href='{0}']";
    
            public BingSearchResultsPage(FluentTest test)
                : base(test)
            {
                At = () => I.Expect.Exists(SearchResultsContainer);
            }
    
            public BingSearchResultsPage FindResultUrl(string url)
            {
                I.Expect.Exists(string.Format(ResultUrlLink, url));
                return this;
            }
        }
    }
