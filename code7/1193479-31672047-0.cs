	using System.IO;
	using System;
	using Newtonsoft.Json;
	class Program
	{
		static void Main()
		{
			string[] request = new String[2];
			request[1] = "Name";
			request[2] = "Occupaonti";
			string json = JsonConvert.SerializeObject(request);
		}
	}
