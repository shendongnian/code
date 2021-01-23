    public class ApplicationConfiguration
    	{
    		public ApplicationConfiguration()
    		{
    		}
    		[DataMember(Order=1)]
    		public int A { get; set; }
    		[DataMember(Order = 3)]
    		public int C { get; set; }
    		[DataMember(Order = 2)]
    		public int B { get; set; }
    	}
