    using System;
    using HtmlAgilityPack;
    
    namespace Demo
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			HtmlDocument doc = new HtmlDocument();
    			doc.Load("HTMLPage1.html"); //or .LoadHtml(/*contentstring*/);
    
    			HtmlNodeCollection iframes = doc.DocumentNode.SelectNodes("//iframe");
    
    			foreach (HtmlNode iframe in iframes)
    			{
    				Console.WriteLine(iframe.GetAttributeValue("width","null"));
    				Console.WriteLine(iframe.GetAttributeValue("height", "null"));
    				Console.WriteLine(iframe.GetAttributeValue("src","null"));
    			}
    
    		}
    	}
    }
