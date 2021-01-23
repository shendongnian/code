    XDocument doc = XDocument.Load(@"http://www.boi.org.il/currency.xml");
    foreach (XElement elm in doc.Elements) 
    {
        Currency currency = new Currency();
    
        currency.Name = elm.Element("NAME").Value;
        currency.Country = elm.Element("COUNTRY").Value;
        currency.CurrencyCode = elm.Element("CURRENCYCODE").Value;
        currency.Rate = Convert.ToDouble(elm.Element("RATE").Value);
        currency.Unit = Convert.ToDouble(elm.Element("UNIT").Value);
        currency.Change = Convert.ToDouble(elm.Element("CHANGE").Value);
        MessageBox.Show(elm.Element("CURRENCYCODE").Value);
        curr.Add(currID, currency);
        currID++;
    }
