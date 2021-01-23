    private void CallWebApi(String xUri)
		{
			String lResults;
			using(WebClient lClient = new WebClient()) {
				try {
					HttpWebRequest lRequest = (HttpWebRequest)WebRequest.Create(xUri);
					lRequest.Accept = "application/json";
					lRequest.ContentType = "application/json";
					HttpWebResponse lResponse = (HttpWebResponse)lRequest.GetResponse();
					using(StreamReader lJsonReader = new StreamReader(lResponse.GetResponseStream())) {
						lResults = lJsonReader.ReadToEnd();
					}
					lRequest = (HttpWebRequest)WebRequest.Create(xUri);
					lRequest.Accept = "application/xml";
					lRequest.ContentType = "application/xml";
					lResponse = (HttpWebResponse)lRequest.GetResponse();
					using(StreamReader lXMLReader = new StreamReader(lResponse.GetResponseStream())) {
						lResults = lXMLReader.ReadToEnd();
					}
				}
				catch(Exception lException) {
					MessageBox.Show(lException.Message);
				}
			}
		}
