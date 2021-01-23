     XDocument doc = XDocument.Load(path);
     var query = from price in doc.Descendants("price")
                 select new
                            {
                               NormalPrice = price.Element("normalprice").Value,
                               PriceTotalInclVat = price.Descendants("entry").Last().Element("pricetotalinclvat").Value
                            };
