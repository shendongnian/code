    using System;
    using System.Linq;
    using System.Xml.Linq;
    using System.Collections.Generic;
    class Program
    {
        public static void Main(String[] args)
        {
            String strPath = @"C:\phototool\photos.xml";
            XDocument doc = XDocument.Load(strPath);
            List<string> lstrKeywords = new List<string>();
            lstrKeywords.Add("beach");
            lstrKeywords.Add("sunset");
    
            var pquery = from p in doc.Descendants("photo")
                         select p;
             
            foreach (string str in lstrKeywords)
            {
                pquery = pquery.Where(i => i.Elements("keywords").Elements("keyword").Select(k => k.Value).ToArray().Contains(str));
            }    
            var pqueryII = from p in pquery
                           select new
                               {
                                   photographer = (string) p.Attribute("photographer"),
                                   description = (string) p.Attribute("description"),
                                   folder = (string) p.Attribute("folder"),
                                   filename = (string) p.Attribute("name"),
                                   lstrKeywords = p.Elements("keywords").Elements("keyword").Select(i => i.Value).ToList(),
                               };
            foreach (var p in pqueryII)
            {
                Console.WriteLine("photographer = {0}, descrption = {1} folder = {2} filename = {3} keywords = {4}", p.photographer, p.description, p.folder, p.filename, String.Join(", ", p.lstrKeywords));
            }
            Console.WriteLine("Press <enter> to continue");
            Console.ReadLine();
        }
    }
