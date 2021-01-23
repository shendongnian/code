    namespace SeleniumTest
    {
        using System;
        using System.Linq;
        using OpenQA.Selenium.IE;
        using OpenQA.Selenium.Support.UI;
        public class Program
        {
            public static void Main(string[] args)
            {
                const string ExamplePageUrl = "http://www.nngroup.com/consulting/ux-research-usability-testing/";
                var webDriver = new InternetExplorerDriver();
            
                webDriver.Navigate().GoToUrl(ExamplePageUrl);
                var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
                wait.Until(w => w.Title == "Nielsen Norman Group: UX Research, Training, and Consulting");
                var paras = webDriver.FindElementsByTagName("p");
            
                var para = paras.FirstOrDefault(p => p.Text.Contains("We test your website or application"));
            
                if (para == null)
                {
                    Console.WriteLine("Dang. Looks like the website changed.");
                }
                else
                {
                    Console.WriteLine(para.Text);
                }
                Console.ReadLine();
            }
        }
    }
