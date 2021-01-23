    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using HtmlAgilityPack;
    namespace HtmlParserDemo
    {
        class Program
        {
            // Update the URL to the page you are trying to parse
            private const string Url = "http://www.bing.com/";
            private const string TagName = "a";
            private const string ClassName = "forumtitle";
            static void Main(string[] args)
            {
                try
                {
                    Console.WriteLine("Getting HTML from: {0}", Url);
                
                    foreach (var category in GetCategories(Url, TagName, ClassName))
                    {
                        Console.WriteLine(category);
                    }
                }
                catch (Exception exception)
                {
                    while (exception != null)
                    {
                        Console.WriteLine(exception);
                        exception = exception.InnerException;
                    }
                }
                finally
                {
                    Console.WriteLine("Press any key to exit...");
                    Console.ReadKey(true);
                }
            }
            public static IEnumerable<string> GetCategories(string url, string htmlTag, string className = "")
            {
                var response = new HttpClient().GetByteArrayAsync(url).Result;
                string source = Encoding.GetEncoding("utf-8").GetString(response, 0, response.Length - 1);
                source = WebUtility.HtmlDecode(source);
                var result = new HtmlDocument();
                result.LoadHtml(source);
                return result.DocumentNode.Descendants()
                    .Where(node =>  node.Name == htmlTag && 
                                    (string.IsNullOrEmpty(className) || (node.Attributes["class"] != null &&
                                     node.Attributes["class"].Value == className)))
                    .Select(node => node.InnerText);
            }
        }
    }
