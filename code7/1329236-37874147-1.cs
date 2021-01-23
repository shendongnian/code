    private async Task<IEnumerable<User>> GetDataSet()
	{
		string source = "";
		using (StreamReader SourceReader = OpenText(pathToFile))
		{
			source = await SourceReader.ReadToEndAsync();
		}
		return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<IEnumerable<User>>(source));
	}
