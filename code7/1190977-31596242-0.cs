    class Program
    {
        public static void Main()
        {
            List<Outline> results = XDocument.Load("http://opml.radiotime.com/Browse.ashx?c=local")
                                       .Descendants("outline")
                                       .Where(o => o.Attribute("text").Value == "FM")
                                       .Elements("outline")
                                       .Select(o => new Outline
                                         {
                                           Text = o.Attribute("text").Value,
                                           URL = o.Attribute("URL").Value
                                         })
                                       .ToList();
        }     
    }
    public class Outline
    {
        public string Text { get; set; }
        public string URL { get; set; }
    }
