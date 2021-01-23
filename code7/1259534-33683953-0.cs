    public class Person
    {
        public string Name { get; set; }
    	
        public string TableOfInformationXml { get; set; }
    	
    	[NotMapped] // <-- This is important, since you will only store the TableOfInformationXml field
    	public DataTable TableOfInformation
    	{
    		get
    		{
    			if (string.IsNullOrWhiteSpace(TableOfInformationXml))
    			{
    				return new DataTable();
    			}
    			var set = new DataSet();
                using (var reader = new StringReader(TableOfInformationXml))
                {
                    set.ReadXml(reader);
                }
    			return set.Tables[0];
    		}
    		set
    		{
    			var set = new DataSet();
    			set.Tables.Add(value);
    			var sb = new StringBuilder();
                using (var stringWriter = new StringWriter(sb))
                {
                    set.WriteXml(stringWriter);
                }
    			TableOfInformationXml = sb.ToString(); 
    		}
    	}
    }
