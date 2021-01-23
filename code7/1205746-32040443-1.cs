    public string Read()
    {
		using (var stream = new FileStream(@"chat.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
		{
			using (var reader = new StreamReader(stream))
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
	}
