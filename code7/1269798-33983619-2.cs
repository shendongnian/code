    using System;
    using System.Xml.Serialization;
    using System.Collections.Generic;
    
    namespace Xml2CSharp
    {
    	[XmlRoot(ElementName="Customer")]
    	public class Customer {
    		[XmlAttribute(AttributeName="Login")]
    		public string Login { get; set; }
    		[XmlAttribute(AttributeName="FIO")]
    		public string FIO { get; set; }
    	}
    
    	[XmlRoot(ElementName="Address")]
    	public class Address {
    		[XmlAttribute(AttributeName="CityName")]
    		public string CityName { get; set; }
    		[XmlAttribute(AttributeName="StationName")]
    		public string StationName { get; set; }
    		[XmlAttribute(AttributeName="StreetName")]
    		public string StreetName { get; set; }
    		[XmlAttribute(AttributeName="House")]
    		public string House { get; set; }
    		[XmlAttribute(AttributeName="Corpus")]
    		public string Corpus { get; set; }
    		[XmlAttribute(AttributeName="Building")]
    		public string Building { get; set; }
    		[XmlAttribute(AttributeName="Flat")]
    		public string Flat { get; set; }
    		[XmlAttribute(AttributeName="Porch")]
    		public string Porch { get; set; }
    		[XmlAttribute(AttributeName="Floor")]
    		public string Floor { get; set; }
    		[XmlAttribute(AttributeName="DoorCode")]
    		public string DoorCode { get; set; }
    	}
    
    	[XmlRoot(ElementName="Phone")]
    	public class Phone {
    		[XmlAttribute(AttributeName="Code")]
    		public string Code { get; set; }
    		[XmlAttribute(AttributeName="Number")]
    		public string Number { get; set; }
    	}
    
    	[XmlRoot(ElementName="Product")]
    	public class Product {
    		[XmlAttribute(AttributeName="Code")]
    		public string Code { get; set; }
    		[XmlAttribute(AttributeName="Qty")]
    		public string Qty { get; set; }
    	}
    
    	[XmlRoot(ElementName="Products")]
    	public class Products {
    		[XmlElement(ElementName="Product")]
    		public Product Product { get; set; }
    	}
    
    	[XmlRoot(ElementName="Order")]
    	public class Order {
    		[XmlElement(ElementName="Customer")]
    		public Customer Customer { get; set; }
    		[XmlElement(ElementName="Address")]
    		public Address Address { get; set; }
    		[XmlElement(ElementName="Phone")]
    		public Phone Phone { get; set; }
    		[XmlElement(ElementName="Products")]
    		public Products Products { get; set; }
    		[XmlAttribute(AttributeName="CallConfirm")]
    		public string CallConfirm { get; set; }
    		[XmlAttribute(AttributeName="PayMethod")]
    		public string PayMethod { get; set; }
    		[XmlAttribute(AttributeName="QtyPerson")]
    		public string QtyPerson { get; set; }
    		[XmlAttribute(AttributeName="Type")]
    		public string Type { get; set; }
    		[XmlAttribute(AttributeName="PayStateID")]
    		public string PayStateID { get; set; }
    		[XmlAttribute(AttributeName="Remark")]
    		public string Remark { get; set; }
    		[XmlAttribute(AttributeName="RemarkMoney")]
    		public string RemarkMoney { get; set; }
    		[XmlAttribute(AttributeName="TimePlan")]
    		public string TimePlan { get; set; }
    		[XmlAttribute(AttributeName="Brand")]
    		public string Brand { get; set; }
    		[XmlAttribute(AttributeName="DiscountPercent")]
    		public string DiscountPercent { get; set; }
    		[XmlAttribute(AttributeName="BonusAmount")]
    		public string BonusAmount { get; set; }
    		[XmlAttribute(AttributeName="Department")]
    		public string Department { get; set; }
    	}
    }
