	public class AutofillValues
	{
		private string fileName = @"d:\settings.db";
		
		public object[] Vendors { get; set; }
		public object[] Products { get; set; }
		public object[] Companies { get; set; }
		
		public void save()
		{
			XmlSerializer x = new XmlSerializer(typeof(AutofillValues));
			// with using there is no need to close the writer explicitely
			//	second parameter - file is created if it does not exist
			using (var writer = new StreamWriter(fileName, false))
			{
				x.Serialize(writer, this);
			}
		}
		
		public void load()
		{
			XmlSerializer x = new XmlSerializer(typeof(AutofillValues));
			AutofillValues av = (AutofillValues)x.Deserialize(new StreamReader(fileName));
			this.Companies = av.Companies;
			this.Vendors = av.Vendors;
			this.Products = av.Products;
		}
	}
 
