    var doc = XDocument.Parse(strfile);      
    var order = doc.Elements("InvoiceOrder").Single();
    XNamespace ns = "http://24sevenOffice.com/webservices";
    
    var orderId = (int)order.Element(ns + "OrderId");
    var customerId = (int)order.Element(ns + "CustomerId");
    var customerName = (string)order.Element(ns + "CustomerName");
    var orderStatus = (string)order.Element(ns + "OrderStatus");
    var dateOrdered = (DateTime)order.Element(ns + "DateOrdered");
    var paymentTime = (int)order.Element(ns + "PaymentTime");
    var totalIncVat = (decimal)order.Element(ns + "OrderTotalIncVat");
    var totalVat = (decimal)order.Element(ns + "OrderTotalVat");
    var currency = (string)order.Elements(ns + "Currency").Elements(ns + "Symbol").SingleOrDefault();
    var typeOfSaleId = (int)order.Element(ns + "TypeOfSaleId");
