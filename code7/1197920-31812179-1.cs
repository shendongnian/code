	[TestMethod]
	public void CleanTextReaderCleans()
	{
		//arrange
		var originalString = "The quick brown fox jumped over the lazy dog.";
		var badChars = new string(new[] {(char) 0x1});
		var concatenated = string.Concat(badChars, originalString);
		//act
		using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(concatenated)))
		{
			using (var reader = new CleanTextReader(stream))
			{
				var newString = reader.ReadToEnd().Trim();
				//assert
				Assert.IsTrue(originalString.Equals(newString));
			}
		}
	}
