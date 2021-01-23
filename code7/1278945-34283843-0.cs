    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    namespace XMLTest
    {
        class Program
        {
            static void Main(string[] args)
            {
    //You can use the XDocument.Load() Method to load a xml from a file path rather than a string
                string xml = "<configuration><title>#ClientOfficialName# Interactive Map</title><subtitle>Powered By Yada</subtitle><logo>assets/images/mainpageglobe.png</logo><style alpha=\"0.9\">    <colors>0xffffff,0x777777,0x555555,0x333333,0xffffff</colors>    <font name=\"Verdana\"/>    <titlefont name=\"Verdana\"/>    <subtitlefont name=\"Verdana\"/></style></configuration>";
                XDocument d = XDocument.Parse(xml);
                Configuration c = new Configuration();
                c.Title = d.Descendants().Where(x => x.Name == "title").FirstOrDefault().Value;
                c.SubTitle = d.Descendants().Where(x => x.Name == "subtitle").FirstOrDefault().Value;
                c.Logo = d.Descendants().Where(x => x.Name == "logo").FirstOrDefault().Value;
    
                Configuration.Style s = new Configuration.Style();
                s.Alpha = (from attr in d.Descendants().Attributes() select attr).Where(x => x.Name == "alpha").FirstOrDefault().Value;
                string tmp = d.Descendants().Where(x => x.Name == "colors").FirstOrDefault().Value;
                foreach (string str in tmp.Split(','))
                {
                    s.Colors.Add(Convert.ToInt32(str, 16));
                }
                s.FontName = (from attr in d.Descendants().Where(x=>x.Name =="font").Attributes() select attr).Where(x => x.Name == "name").FirstOrDefault().Value;
                s.TitleFontName = (from attr in d.Descendants().Where(x => x.Name == "titlefont").Attributes() select attr).Where(x => x.Name == "name").FirstOrDefault().Value;
                s.SubtitleFontName = (from attr in d.Descendants().Where(x => x.Name == "subtitlefont").Attributes() select attr).Where(x => x.Name == "name").FirstOrDefault().Value;
    
                c.MyStyle = s;
                
                Console.WriteLine(c.ToString());
                Console.ReadKey();
            }
        }
        public class Configuration : IComparable
        {
    
            public string Title;
            public string SubTitle;
            public string Logo;
            public Style MyStyle;
    
            public override string ToString()
            {
                return string.Format("Configuration : Title: {0}, Subtitle {1}, Logo {2}, Style: {3}",Title,SubTitle,Logo,MyStyle.ToString());
            }
            public class Style
            {
                public string Alpha;
                public List<int> Colors = new List<int>();
                public string FontName;
                public string TitleFontName;
                public string SubtitleFontName;
    
                public override string ToString()
                {
                    string s = "Alpha :" +Alpha;
                    s+= ", Colors: ";
                    foreach(int i in Colors){
                        s += string.Format("{0:x},",i);
                    }
                    s += " FontName :" + FontName;
                    s += " TitleFontName :" + TitleFontName;
                    s += " SubTitleFontName :" + SubtitleFontName;
                    return s;
                }
            }
    
            public int CompareTo(object obj)
            {
                if ((obj as Configuration) == null)
                {
                    throw new ArgumentException("Not instance of configuration");
                }
                //Very simple comparison, ranks by the title in the comparison object, here you could compare all the other values e.g Subtitle , logo and such to test if two instances are Equal
                return String.Compare(this.Title, ((Configuration)obj).Title, true);
            }
        }
    }
