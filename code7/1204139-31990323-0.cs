    var customers = XElement.Parse(@"<Seq1>
      <Customer CustomerID=""g"">G</Customer>
      <Customer CustomerID=""p"">P</Customer>
      <Customer CustomerID=""r"">R</Customer>
      <Customer CustomerID=""s"">S</Customer>
    </Seq1>");
    var orders = XElement.Parse(@"<Seq2>
      <Order OrderID=""11"" CID=""r"">flash</Order>
      <Order OrderID=""12"" CID=""r"">mouse</Order>
      <Order OrderID=""21"" CID=""s"">phone</Order>
      <Order OrderID=""22"" CID=""s"">pc</Order>
      <Order OrderID=""23"" CID=""s"">camera</Order>
      <Order OrderID=""41"" CID=""p"">card</Order>
    </Seq2>");
    var results = customers.Descendants("Customer").Join(orders.Descendants("Order"),
    	    c => c.Attribute("CustomerID").Value,
    	    o => o.Attribute("CID").Value,
    	    (c, o) => new{ Customer = c, Order = o})
    	.GroupBy(x => x.Customer)
    	.Select(g=>
    	{
    		var customerOrders = g.Select(x=>x.Order).ToArray();
    		var customer = g.Key;
    		var @group = customerOrders.Any()? new XElement    ("Group",customerOrders):new XElement("Group");
    		@group.SetAttributeValue("Count", customerOrders.Length);
	    	return new XElement("Join",new[]{customer, @group});
    	});
    new XElement("GroupJoin", results).Dump();
