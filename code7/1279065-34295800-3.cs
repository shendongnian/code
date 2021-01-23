    class Program
	{
		const string MutexId = "ENTER YOUR GUID HERE, OR READ FROM APP";
		public static void Main(string[] args)
		{
			using (var instance = new SingleInstance(new Guid(MutexId)))
			{
				if (instance.IsFirstInstance)
				{
					instance.ArgumentsReceived += Instance_ArgumentsReceived;
					instance.ListenForArgumentsFromSuccessiveInstances();
					DoMain(args);
				}
				else
				{
					instance.PassArgumentsToFirstInstance(args);
				}
			}
		}
		private static void Instance_ArgumentsReceived(object sender, ArgumentsReceivedEventArgs e)
		{
			TryProcessAccount(e.Args);
		}
        // This is the main part of the program I use, so I can call my exe with program.exe 123 42424 to have it open that specific account in chrome. Replace with whatever code you want to happen when you have multiple instances.
		private static void TryProcessAccount(string[] args)
		{
			if (args == null || args.Length < 2 || args[0] == null || args[1] == null || args[0].Length != 3) { return; }
			var openAccountString = GetOpenAccountString(args[0], args[1]);
			Write(openAccountString);
		}
		private static void DoMain(string[] args)
		{
			TryProcessAccount(args);
			JObject data = Read();
			while ((data = Read()) != null)
			{
				if (data != null)
				{
					var processed = ProcessMessage(data);
					Write(processed);
					if (processed == "exit")
					{
						return;
					}
				}
			}
		}
		public static string GetOpenAccountString(string id, string secondary)
		{
			return JsonConvert.SerializeObject(new
			{
				action = "open",
				id = id,
				secondary = secondary
			});
		}
		public static string ProcessMessage(JObject data)
		{
			var message = data["message"].Value<string>();
			switch (message)
			{
				case "test":
					return "testing!";
				case "exit":
					return "exit";
				case "open":
					return GetOpenAccountString("123", "423232");
				default:
					return message;
			}
		}
		public static JObject Read()
		{
			var stdin = Console.OpenStandardInput();
			var length = 0;
			var lengthBytes = new byte[4];
			stdin.Read(lengthBytes, 0, 4);
			length = BitConverter.ToInt32(lengthBytes, 0);
			var buffer = new char[length];
			using (var reader = new StreamReader(stdin))
			{
				while (reader.Peek() >= 0)
				{
					reader.Read(buffer, 0, buffer.Length);
				}
			}
			return (JObject)JsonConvert.DeserializeObject<JObject>(new string(buffer))["data"];
		}
		public static void Write(JToken data)
		{
			var json = new JObject
			{
				["data"] = data
			};
			var bytes = System.Text.Encoding.UTF8.GetBytes(json.ToString(Formatting.None));
			var stdout = Console.OpenStandardOutput();
			stdout.WriteByte((byte)((bytes.Length >> 0) & 0xFF));
			stdout.WriteByte((byte)((bytes.Length >> 8) & 0xFF));
			stdout.WriteByte((byte)((bytes.Length >> 16) & 0xFF));
			stdout.WriteByte((byte)((bytes.Length >> 24) & 0xFF));
			stdout.Write(bytes, 0, bytes.Length);
			stdout.Flush();
		}
	}
