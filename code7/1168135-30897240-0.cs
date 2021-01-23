        string first = "John";
        string last = "D";
        XDocument xd = XDocument.Parse(xml);
        xd.Root.Element("product").Elements("auto").ToList()
            .ForEach(x=>
                {
                var name = x.Descendants("name").First();
                if (name.Element("first").Value != first
                    && name.Element("last").Value != last)
                    x.Remove();
                });
        Console.WriteLine(xd);
