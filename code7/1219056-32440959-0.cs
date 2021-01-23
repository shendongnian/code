		[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
		[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
		public partial class complex {
			[System.Xml.Serialization.XmlElementAttribute("complex")]
			public complexComplex[] complex1 { get; set; }
			[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
			public partial class complexComplex {
				public string field { get; set; }
				[System.Xml.Serialization.XmlTextAttribute()]
				public string[] Text { get; set; }
			}
		}
