	public class DoesStuffToFiles 
	{
		private FileStream OpenTextFile()
		{
			return new FileStream("text_file.txt",
								  FileMode.Open, 
								  FileAccess.Read, 
								  FileShare.ReadWrite);
		}
		public void SomeMethod1()
		{
			using (var file = OpenTextFile())
			{
			
			}
		}
		
		public void SomeMethod2()
		{
			using (var file = OpenTextFile())
			{
			
			}
		}
	}
