    using System;
    using System.IO;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Edge;
    using OpenQA.Selenium.Remote;
    using OpenQA.Selenium.Support.UI;
    
    namespace SampleGetText
    {
        public class Program
        {
            static void Main(string[] args)
            {
                var text = GetText();
            }
    
            public static string GetText()
            {
                RemoteWebDriver driver = null;
                string serverPath = "Microsoft Web Driver";
                // Makes sure we uses the correct ProgramFiles depending on Enviroment
                string programfiles = Environment.Is64BitOperatingSystem ? "%ProgramFiles(x86)%" : "%ProgramFiles%";
    
                try
                {
                    // Gets loaction for MicrosoftWebDriver.exe
                    serverPath = Path.Combine(System.Environment.ExpandEnvironmentVariables(programfiles), serverPath);
    
                    //Create a new EdgeDriver using the serverPath
                    EdgeOptions options = new EdgeOptions();
                    options.PageLoadStrategy = EdgePageLoadStrategy.Eager;
                    driver = new EdgeDriver(serverPath, options);
    
                    //Set a page load timeout for 5 seconds
                    driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(5));
    
                    // Navigate to my blog
                    driver.Url = "https://blogs.msdn.microsoft.com/thebeebs/";
    
                    // Find the first element on my screen with CSS class entry-title and return the text
                    IWebElement myBlogPost = driver.FindElement(By.ClassName("entry-title"));
                    return myBlogPost.Text;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return "";
                }
                finally
                {
                    if (driver != null)
                    {
                        driver.Close();
                    }
                }
            }
        }
    }
