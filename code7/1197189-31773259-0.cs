	class Program
	{
		static void Main()
		{
			Dictionary<string, string> DIC = new Dictionary<string, string> ();
			DIC.Add("NAME", "aly");
			DIC.Add("AGE", "TWENTY");
			DIC.Add("LOVE", "NO");
			DIC.Add("GENDER", "MALE AWII");
			DIC.Add("BROTHER", "NO");
			DIC.Add("SISTER", "HAVE TOw");
			DIC.Add("FACULTY", "CS");
			DIC.Add("country ", "us");
			
			string value = this.Search(DIC, "country");
            // Do something with value
		}
		
		private static string Search(Dictionary<string, string> DIC, string wanted) 
		{
			string value = string.Empty;
			if (DIC.ContainsKey(wanted)) 
			{
				value = DIC[wanted];
			}
			return value;
		}
	}
