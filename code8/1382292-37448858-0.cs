    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Collections.Specialized;
    using System.IO;
    using System.Net;
    using System.Text.RegularExpressions;
    namespace Crawler
    {
            //Create information handling
        public interface IWidow
        {
            string Say(string input);
            string Success(string input);
            string MinorErr(string input);
            string FatalErr(string input);
            string Debug(string input);
        }
        /*
         * Intiate the information handling
         * and create the color coordination.
         */
        public class ConsoleInformative : IWidow
        {
            public string Say(string input)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("[{0}] {1}",DateTime.Now.ToString("h:mm:ss tt"),input);
                return input;
            }
            public string Success(string input)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("[{0}] {1}", DateTime.Now.ToString("h:mm:ss tt"), input);
                return input;
            }
            public string MinorErr(string input)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("[{0}] {1}", DateTime.Now.ToString("h:mm:ss tt"), input);
                return input;
            }
            public string FatalErr(string input)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[{0}] {0}", DateTime.Now.ToString("h:mm:ss tt"), input);
                return input;
            }
            public string Debug(string input)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("[{0}] {1}",DateTime.Now.ToString("h:mm:ss tt"), input);
                return input;
            }
        }
        public class BlackWidow
        {
            public BlackWidow(string url)
            {
                GetWebInfo(url);
            }
            /*
             * Make a request to the web host in
             * this case it is Google.
             */
            private static string GetWebInfo(string url)
            {
                string logPath = string.Format(@"{0}\html.txt", Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory));
                string errPath = string.Format(@"{0}\error.txt", Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory));
                HttpWebRequest requests = (HttpWebRequest)HttpWebRequest.Create(url);
                requests.ProtocolVersion = HttpVersion.Version10;
                requests.UserAgent = "A .NET Web Crawler";
                IWebProxy proxy = requests.Proxy;
                IWidow info = new ConsoleInformative();
                /*
                 * Used cached credentials to access
                 * proxy if there is one.
                 */
                info.Say("Checking if you're behind a proxy");
                if (proxy != null)
                {
                    try
                    {
                        info.Say("Proxy found attempting to login with cached credentials..");
                        string proxyUri = proxy.GetProxy(requests.RequestUri).ToString();
                        requests.UseDefaultCredentials = true;
                        requests.Proxy = new WebProxy(proxyUri, false);
                        requests.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
                    }
                    /*
                     * Catch exception if hte cached
                     * credentials fail to load.
                     */
                    catch (Exception e)
                    {
                        info.FatalErr("Unable to verify cached credentials..");
                        File.WriteAllText(errPath, e.ToString());
                        info.Debug("Wrote error to file for further analysis, exiting process..");
                    }
                }
                info.Success("Logged in with cached credentials, continuing process.");
                WebResponse providedResponse = requests.GetResponse();
                Stream stream = providedResponse.GetResponseStream();
                StreamReader readInformation = new StreamReader(stream);
                string htmlOutput = readInformation.ReadToEnd();
                File.WriteAllText(logPath, htmlOutput);
                return htmlOutput;
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                IWidow info = new ConsoleInformative();
                try
                {
                    string searchQuery = "test";
                    string searchEngine = "https://google.com";
                    NameValueCollection search = new NameValueCollection();
                    Regex linkParser = new Regex(@"\b(?:https?://|www\.)\S+\b", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                    info.Say("Attempting to connect to the site..");
                    BlackWidow blackWidow = new BlackWidow(searchEngine);
                    info.Success(string.Format("Connected to site, writing HTML to file, and searching {0} with query {1}.", searchEngine,searchQuery));
                    search.Add("q", searchQuery);
                    
                }
                    
                /*
                 * Catch all exceptions and write them
                 * to a file for futher analysis if any
                 * occur during the process.
                 */
                catch (Exception e)
                {
                    var filePath = AppDomain.CurrentDomain.BaseDirectory;
                    info.FatalErr(string.Format("Exception thrown: {0}", e.ToString()));
                    File.WriteAllText(string.Format(@"{0}\errorlog.LOG",filePath), e.ToString());
                    info.Debug(string.Format("Wrote Exception to file located in {0}",filePath));
                }
                Console.ReadLine();
            }
        }
    }
