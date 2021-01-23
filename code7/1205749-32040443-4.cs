    public class ChatHandler
	{
		public FileStream stream;
		//StreamWriter writer;
		StreamReader reader;
		public ChatHandler()
		{
			stream = new FileStream(@"chat.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
			//writer = new StreamWriter(stream);
			reader = new StreamReader(stream);
		}
		public void Write(string line)
		{
			using (var fileStream = new FileStream(@"chat.txt", FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
			{
				using (var writer = new StreamWriter(fileStream))
				{
					writer.WriteLineAsync(line);
					writer.Flush();
				}
			}
		}
		public string Read()
		{
			string tmp = "";
			string line;
			while ((line = reader.ReadLine()) != null)
			{
				tmp += line + '\n';
			}
			return tmp;
		}
	}
