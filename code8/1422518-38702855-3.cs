    class Program
	{
		private static string serverUrl;
		static void Main(string[] args)
		{
			Console.WriteLine("Please enter the URL to send the XML File");
			serverUrl = Console.ReadLine();
			string fileName = "";
			do
			{
				Console.WriteLine("Please enter the XML File you Wish to send");
				Thread t = new Thread(new ParameterizedThreadStart(send));
				t.Start(fileName = Console.ReadLine());
			}
    while (fileName != ""); //Ends if user enters an empty line
		}
		static private void send(object url)
		{
			try
			{
				//ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
				HttpWebRequest request = (HttpWebRequest)WebRequest.Create(serverUrl);
				byte[] bytes;
				//Load XML data from document 
				XmlDocument doc = new XmlDocument();
				doc.Load((string)url);
				string xmlcontents = doc.InnerXml;
				 ...
				Console.Write(responseStr + Environment.NewLine);
			}
			catch (Exception e)
			{
				Console.WriteLine("An Error Occured" + Environment.NewLine + e);
				Console.ReadLine();
			}
		}
	}
