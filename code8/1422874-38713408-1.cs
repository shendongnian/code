	public class MyModel
	{
		private string fieldName;
		
		public int Id { get; set; }
		public string Description { get; set; }
		public string LanguageCode { get; set; }
		public string FiledName 
		{ 
			get { return filedName; }
			set
			{
				if(!string.IsNullOrEmpty(value))
					fieldName = value.ToUpper();
				else
					fieldName = value;				
			}
		}	
	}
