	private void timer1_Tick( object sender, EventArgs e ) {
		HttpWebRequest request = (HttpWebRequest)WebRequest.Create("a URL goes here");
		request.ContentType = "application/json";
		request.Method = "POST";
		String query = "{some json stuff goes here}";
		String result = String.Empty;
		using ( StreamWriter writeData = new StreamWriter(request.GetRequestStream()) ) {
			writeData.Write(query);
			writeData.Flush();
			using ( HttpWebResponse response = (HttpWebResponse)request.GetResponse() ) {
				using ( StreamReader readData = new StreamReader(response.GetResponseStream()) ) {
					result = readData.ReadToEnd();
				}
			}
		}
		logOutput.Text = result;
		File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "log.txt", result + "\r\n");
	}
}
