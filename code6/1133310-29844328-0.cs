    var bodyReader = message.GetReaderAtBodyContents();
			bodyReader.ReadStartElement("Binary");
			byte[] rawBody = bodyReader.ReadContentAsBase64();
			MemoryStream ms = new MemoryStream(rawBody);
			StreamReader sr = new StreamReader(ms);
			string content = string.Empty;
			using (StreamReader reader = new StreamReader(ms, Encoding.UTF8))
			{
				content = reader.ReadToEnd();
			}
