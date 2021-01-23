     public class PathTemplate
     {
         public string path { get; set; }
         public string template { get; set; }
     }
      public static string getxml()
        {
            return "<pathsSettings>" +
                   "<paths>" +
                   "<add Path=\"C:\\tests\\first\" TemplateId=\"123456\"></add>" +
                   "<add Path=\"C:\\tests\\second\" TemplateId=\"tem_56hyNijCXxGP52ZrgdWziC \"></add>" +
                   "<add Path=\"C:\\tests\\third\" TemplateId=\"tem_2wWT6YfGkDXSntEPKhHCWB \"></add>" +
                   "</paths>" +
                   "</pathsSettings>";
        }
    var xdoc = XDocument.Parse(getxml());
           
            Console.WriteLine(xdoc);
            var pts = xdoc.Elements("pathsSettings")
                .Elements("paths")
                .Elements("add").
                Select(p => new PathTemplate()
                {
                    path = p.Attribute("Path").Value.ToString(),
                    template = p.Attribute("TemplateId").Value.ToString()
                }).ToList();
