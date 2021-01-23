    using HtmlAgilityPack;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication2
    {
        class Program
        {
    
    
            static void Main(string[] args)
            {
                using (var client = new HttpClient())
                {
    
                    List<string> source = new List<string>();
    
                    HtmlWeb web = new HtmlWeb();
                    string url = "http://www.jornaldenegocios.pt/mercados/bolsa/detalhe/wall_street_cada_vez_mais_perto_de_maximo_historico.html";
                    HtmlDocument document = web.Load(url);
                    Uri myUri = new Uri(url);
                    string host = myUri.Host;
    
                    var head = document.DocumentNode.SelectSingleNode("//head");
                    var meta = head.SelectNodes("//meta").AsEnumerable();
                    var link = document.DocumentNode.SelectSingleNode("//head").SelectNodes("//link").AsEnumerable();
                    var urls = document.DocumentNode.SelectNodes("//img")
                            .Select(e => e.GetAttributeValue("src", null))
                            .Where(s => !string.IsNullOrEmpty(s))
                            .Where(s => !s.StartsWith("//"))
                            .Select(s => s.StartsWith("http") ? s : myUri.Scheme + "://" + host + s);
    
                    var titulo = "";
                    var descricao = "";
                    var linkImg = "";
                    var linkIcon = "";
                    var linkImgAlt = "";
                    var length = 0L;
    
    
    
                    var fbProperties = (head.SelectNodes("//meta[contains(@property, 'og:')]") ?? Enumerable.Empty<HtmlNode>())
                        .ToDictionary(n => n.Attributes["property"].Value, n => n.Attributes["content"].Value);
    
    
                    linkIcon = (head.SelectSingleNode("//link[contains(@rel, 'apple-touch-icon')]")?.Attributes["href"]?.Value) ??
                        (head.SelectSingleNode("//link[contains(@rel, 'icon')]")?.Attributes["href"]?.Value) ??
                        host + "/favicon.ico";
    
    
                    var title = head.SelectSingleNode("//title")?.InnerText;
    
    
    
                    if (fbProperties.TryGetValue("og:title", out titulo) == false || titulo == null)
                    {
                        titulo = (title ?? host);
                    }
    
                    if (fbProperties.TryGetValue("og:description", out descricao) == false || descricao == null)
                    {
                        descricao = ("none");
                    }
    
                    if (fbProperties.TryGetValue("og:image", out linkImg) == false || linkImg == null)
                    {
                        linkImg = (linkImgAlt ?? "none");
                    }
    
                    foreach (var node in urls)
                    {
                        source.Add(node);
                    }
    
                    
    
                    foreach (var links in source)
                    {
                        try
                        {
                            var response = client.SendAsync(new HttpRequestMessage
                            {
                                Method = HttpMethod.Head,
                                RequestUri = new Uri(links)
                            }).Result;
    
                            var fileLength = response.Content.Headers.ContentLength;
    
                            Console.WriteLine($"{links}: {fileLength} bytes");
    
                            if (length < fileLength)
                            {
                                linkImgAlt = links;
                                length = fileLength ?? 0;
                            }
    
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
    
                    }
    
    
                    Console.WriteLine("");
                    Console.WriteLine("Titulo:");
                    Console.WriteLine(titulo);
                    Console.WriteLine("");
                    Console.WriteLine("Descriçao:");
                    Console.WriteLine(descricao);
                    Console.WriteLine("");
                    Console.WriteLine("Link da Imagem:");
                    Console.WriteLine(linkImg);
                    Console.WriteLine("");
                    Console.WriteLine("Link do Icon:");
                    Console.WriteLine(linkIcon);
                    Console.WriteLine("");
                    Console.WriteLine("Link da Imagem:");
                    Console.WriteLine(length);
                    Console.WriteLine("");
                    Console.WriteLine("Link da Imagem (alt):");
                    Console.WriteLine(linkImgAlt);
    
                    Console.ReadLine();
                }
            }
        }
    }
