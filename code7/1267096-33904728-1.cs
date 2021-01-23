	public class A
	{
		protected readonly List<string> fileHeaders = new List<string>
		{
			"Last Name", "First Name", "Middle Name", "Suffix", "Degree", 
		};
		
		public List<string> FileHeaders
		{
			get
			{
				return fileHeaders;
			}
		}
	}
	public class B : A
	{
		public B()
		{
			fileHeaders.Add("Something Else");
		}
	}
