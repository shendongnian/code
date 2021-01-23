	namespace ConsoleApplication1
	{
		using System;
		using System.IO;
		using System.Xml.Serialization;
		internal class Program
		{
			private static void Main(string[] args)
			{
                var order = new PurchaseOrder { ItemsOrders = new Item[2] };
                order.ItemsOrders[0] = new Item { ItemID = "1", ItemPrice = 1723 };
                order.ItemsOrders[1] = new Item { ItemID = "2", ItemPrice = 4711 };
				var serializer = new XmlSerializer(typeof(PurchaseOrder));
				using (var writer = new StringWriter())
				{
					serializer.Serialize(writer, order);
					Console.WriteLine(writer.ToString());
				}
			}
		}
		public class PurchaseOrder
		{
			[XmlElement("Item")]
			public Item[] ItemsOrders { get; set; }
		}
		public class Item
		{
			public string ItemID { get; set; }
			public decimal ItemPrice { get; set; }
		}
	}
----------
	<?xml version="1.0" encoding="utf-16"?>
	<PurchaseOrder xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
	  <Item>
		<ItemID>1</ItemID>
		<ItemPrice>1723</ItemPrice>
	  </Item>
	  <Item>
		<ItemID>2</ItemID>
		<ItemPrice>4711</ItemPrice>
	  </Item>
	</PurchaseOrder>
	Press any key to continue . . .
