    var xml = "<<YOUR_XML>>";
    xml = Regex.Replace(xml, @"<\s+([\w:-])", "<$1");
    xml = Regex.Replace(xml, @"</\s+([\w:-]+>)", "</$1");
    xml = Regex.Replace(xml, @"(?s)<!--.*?->", string.Empty);
    XElement xe = null;
    try
    {
       xe = XElement.Parse(xml);
       var tags = xe.DescendantsAndSelf()
          .Where(p => p.Name == "T_C_B" || p.Name == "U_C_B")
          .Select(p => new { names = p.Descendants()
                          .Select(m => m.Name.LocalName + "=" + m.Value)
                          .ToList() })
          .ToList();
       var res = string.Empty;
       foreach (var s in tags)
          res += (string.IsNullOrEmpty(res) ? "" : "|") +
                   string.Join("|", s.names);
    }
    catch(Exception e) 
    {
    }
