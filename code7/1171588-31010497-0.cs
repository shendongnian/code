	void Main()
	{
		XDocument doc= XDocument.Load(@"d:\test2.xml");
		var orders = doc.Root.Elements("ORDER")
			.Select (o => new Order
				{
					EmpNumber=o.Element("EMPNUMBER").Value,
					ItemName=o.Element("ITEMNAME").Value,
					TimeStamp=o.Element("DATETIMESTAMP").Value,
					Shipments=o.Element("SHIPMENTLIST").Elements("ACCT").Select (e => new Shipment{Account= e.Value}).ToList()
				}
			);
			
		orders.Dump();	
	}
	
	
	
	class Order
	{
		public Order ()
		{
			this.Shipments=new List<Shipment>();
		}
		public string EmpNumber { get; set; }
		public string ItemName { get; set; }
		public string TimeStamp { get; set; }  //should be date time
		public string Department { get; set; }
		public List<Shipment> Shipments { get; set; }
	}
	
	class Shipment
	{
		public string Account { get; set; }
	}
