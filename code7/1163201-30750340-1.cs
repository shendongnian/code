    var serializer = new XmlSerializer(typeof(InvoiceList));
    
    using (var reader = new StringReader(strInvoices))
    {
        var list = (InvoiceList)serializer.Deserialize(reader);
    }
