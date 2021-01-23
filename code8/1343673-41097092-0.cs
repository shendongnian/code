        using HtmlAgilityPack;
        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Net;
        using System.Text;
        using System.Threading.Tasks;
        namespace ConsoleApplication1
        {
            class Program
            {
                static void Main(string[] args)
                {
                    WebClient wc = new WebClient();
                    string html = wc.DownloadString("http://www.imdb.com/title/tt0482571/");
                        
                    HtmlDocument doc = new HtmlDocument();
                    doc.LoadHtml(html);
                    var castListRows = doc.DocumentNode.SelectNodes("//table[@class='cast_list']/tr");
                    foreach (var castListRow in castListRows)
                    {
                        var nameNode = castListRow.Descendants().Where(n => n.Attributes.Contains("itemprop") && n.Attributes["itemprop"].Value == "name").FirstOrDefault();
                        if (nameNode != null)
                        {
                            var characterCell = castListRow.CreateNavigator().Select("td[@class='character']/div/a");
                            if (characterCell.MoveNext())
                            {
                                Console.WriteLine("Actor={0}, Character={1}", characterCell.Current.InnerXml, nameNode.InnerText);
                            }					
                        }
                    }
                    Console.ReadKey();
                }
            }
        }
