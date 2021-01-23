    class Program
	{
		static ManagementScope scope =
			   new ManagementScope(
				   "\\\\ServerIP\\root\\cimv2");
		static string username = "Test";
		static void Main(string[] args)
		{
			string partComponent = "Win32_UserAccount.Domain='Domain',Name='"+username+"'";
			ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_GroupUser WHERE PartComponent = \"" + partComponent + "\"");
			using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query))
			{
				var result = searcher.Get();
				foreach (var envVar in result)
				{
					ManagementObject groupComponent = new ManagementObject("\\\\ServerIP\\root\\cimv2", envVar["GroupComponent"].ToString(), null);
					Console.WriteLine(groupComponent["Name"]);
				}
			}
			Console.ReadLine(); 
		}
	}
