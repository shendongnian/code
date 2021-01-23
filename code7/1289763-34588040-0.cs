    var prices = from item in doc.Descendants("Item")
                 from summary in item.Elements("OfferSummary")
                 from lowestNewPrice in summary.Elements("LowestNewPrice")
                 select new
                 {
                     ASIN = (string) item.Element("ASIN"),
                     FormattedPrice = (string) lowestNewPrice.Element("FormattedPrice")
                 };
