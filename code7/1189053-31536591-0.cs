	void Main()
	{
		CommandParamater exampleCommand = new CommandParamater
		{
			Command = "Foo",
			Parameter = new Parameter 
			{
				ApplicationString = "App String Foo",
				Configured = true,
				Hostname = "Bar",
				IPAddress = "8.8.8.8",
				UniqueID = Guid.NewGuid().ToString(),
				Username = "FooBar"
			}
		};
		
		string uri = "http://localhost:8084";
		string data = JsonConvert.SerializeObject(exampleCommand);
	
		Html htmlClient = new Html();
		htmlClient.Post(uri, data, "application/json");
	}
	
	public class Html 
	{
		public string Post(string uri, string data, string contentType)
		{
			byte[] dataBytes = Encoding.UTF8.GetBytes(data);
				
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
			request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
			request.ContentType = contentType;
			request.ContentLength = dataBytes.Length;
			
			using (Stream stream = request.GetRequestStream())
			{
				stream.Write(dataBytes, 0, dataBytes.Length);
			}
			
			using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
			using (Stream stream = response.GetResponseStream())
			using (StreamReader reader = new StreamReader(stream))
			{
				return reader.ReadToEnd();
			}
		}
	}
	
	
	public class Parameter
	{
		[JsonProperty("Configured")]
		public bool Configured { get; set; }
		
		[JsonProperty("ApplicationString")]
		public string ApplicationString { get; set; }
		
		[JsonProperty("Hostname")]
		public string Hostname { get; set; }
		
		[JsonProperty("IPAddress")]
		public string IPAddress { get; set; }
		
		[JsonProperty("UniqueID")]
		public string UniqueID { get; set; }
		
		[JsonProperty("Username")]
		public string Username { get; set; }
	}
	
	public class CommandParamater
	{
		[JsonProperty("Command")]
		public string Command { get; set; }
		
		[JsonProperty("parameter")]
		public Parameter Parameter { get; set; }
	}
