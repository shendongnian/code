	public class ExtraEntityProperty
	{
		public int Id { get; set; } // PK
		public string EntityName { get; set; }
		public string PropertyType { get; set; }
		public string PropertyName { get; set; }
	}
	
	public class ExtraEntityPropertyValue
	{
		public int Id { get; set; } // PK
		public int ExtraEntityPropertyId { get; set; } // FK
		public string PropertyValue { get; set; }
	}
