	public class Base
	{
		protected List<string> fileHeaders;
		public List<string> FileHeaders
		{
			get
			{
				return fileHeaders;
			}
		}
	}
	public class A : Base
	{
		public A()
		{
			fileHeaders = new List<string>
			{"Last Name", "First Name", "Middle Name", "Suffix", "Degree"};
		}
	}
	public class B : Base
	{
		public B()
		{
			fileHeaders = new List<string>
			{"Last Name", "First Name", "Middle Name", "Suffix", "Degree", "Something Else"};
		}
	}
