    public class MyHTTPRequestManager
	{
		public delegate void GettingDataCallback(string dataStr);
		private static MyHTTPRequestManager instance = null;
		public static MyHTTPRequestManager Instance{
			get{
				if(null == instance)
					instance = new MyHTTPRequestManager();
				return instance;
			}
		}
		public void GetDataFromUrl(string strURL,GettingDataCallback callback)
		{
			Console.WriteLine ("Begin request data.");
			System.Net.HttpWebRequest request;
			request = (System.Net.HttpWebRequest)WebRequest.Create(strURL);
			System.Net.HttpWebResponse response;
			response = (System.Net.HttpWebResponse)request.GetResponse();
			System.IO.StreamReader myreader = new System.IO.StreamReader(response.GetResponseStream(), Encoding.UTF8);
			string responseText = myreader.ReadToEnd();
			myreader.Close();
			Console.WriteLine ("Getting succeed, invoke callback.");
			callback.Invoke (responseText);
		}
	}
