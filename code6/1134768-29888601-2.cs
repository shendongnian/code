	class Program
	{
		private static Regex reg = new Regex(@"COD/ID:\s(?<id>\d+)\r\nPRJ/NAME:\s(?<name>.+?)\r\nPRJ/EMAIL:\s(?<email>\S+?@\S+?\.\S+?)\r\nPRJ/DESCRIPTION:\s(?<description>.*?)\r\n");
		static void Main(string[] args)
		{
			StringBuilder intermediateStringBuilder = new StringBuilder();
			using (StreamReader reader = new StreamReader(@"YourInputPath.txt",true))
			{				
				using (StreamWriter writer = new StreamWriter("YourOutputPath.txt"))
				{
					while (reader.Peek() > 0)
					{
						string line = reader.ReadLine();
						if (!string.IsNullOrWhiteSpace(line))
						{
							intermediateStringBuilder.AppendLine(line);
						}
						else
						{
							WriteToFile(intermediateStringBuilder, writer);
						}
					} 
					WriteToFile(intermediateStringBuilder,writer);
				}
			}
		}
		private static void WriteToFile(StringBuilder intermediateStringBuilder, StreamWriter writer)
		{
			Match m = reg.Match(intermediateStringBuilder.ToString());
			writer.WriteLine("{0}|{1}|{2}|{3}", m.Groups["id"].Value, m.Groups["name"].Value, m.Groups["email"].Value, m.Groups["description"].Value);
			intermediateStringBuilder.Clear();
		}
	}
