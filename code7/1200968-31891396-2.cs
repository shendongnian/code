    var customersxml = @"<Customers>
      <Customer CustomerID='alc'>Alice</Customer>
    </Customers>";
    var ordersxml = @"<Orders>
    <Order OrderID='001' CID='alc'>apple</Order>
    </Orders>";
    
    var result = new XElement("Result",
    						  from customer in XElement.Parse(customersxml).Elements("Customer")
    						  join order in XElement.Parse(ordersxml).Elements("Order")
    						  on (string)customer.Attribute("CustomerID") equals (string)order.Attribute("CID")
    						  select new XElement("Join", customer, order));
    Console.WriteLine(result.ToString());
