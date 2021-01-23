    var date = new DateTime(2015, 12, 7); //the date on which you want to filter
    var product_2015_12_07 = xDoc.Descendants("CruiseProduct")
                                    .Where(cp => cp.Element("Name").Value == "name_one" ||
                                                 cp.Descendants("Date")
                                                   .Any(d => DateTime.Parse(d.Value).Date.Equals(date.Date)));
