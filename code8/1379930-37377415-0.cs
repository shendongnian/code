	var myxml =
		@"<?xml version='1.0' encoding='utf-8'?>
		<methodCall>
			<methodName>LogIn</methodName>
			<params>
				<param>
					<value><string></string></value>
				</param>
				<param>
					<value><string></string></value>
				</param>
				<param>
					<value><string></string></value>
				</param>
				<param>
					<value>
						<string>OSTestUserAgent</string>
					</value>
				</param>
			</params>
		</methodCall>";
	var request = (HttpWebRequest)WebRequest.Create("http://api.opensubtitles.org:80/xml-rpc");
	request.Method = "POST";
	using (var dataStream = new StreamWriter(await request.GetRequestStreamAsync()))
	{
		dataStream.Write(myxml);
		dataStream.Dispose();
	}
	string result = null;
	using (var response = await request.GetResponseAsync())
	using (var stream = response.GetResponseStream())
	using (var reader = new StreamReader(stream, Encoding.ASCII))
	{
		result = reader.ReadToEnd();
	}
	Debug.WriteLine(result);
