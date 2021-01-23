    XDocument xml = XDocument.Load("path_to_file");
    string newCountry = "UAE";
    XElement countries = xml.Descendants("Countries").First();
    XElement el = countries.Elements().FirstOrDefault(x => x.Value == newCountry);
    if (el == null)
    {
        el = new XElement("country");
        el.Value = newCountry;
        countries.Add(el);        
    }
    //Console.WriteLine(countries.ToString());
