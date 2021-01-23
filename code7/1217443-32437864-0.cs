    public class JiraTest
    {
		internal IEnumerable<FilterKopf> GetFavouriteFilters()
		{
			string url = "http://http://jira-test.myserver.de//rest/api/2/filter/favourite";
			var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
			httpWebRequest.ContentType = "application/json";
			httpWebRequest.Method = "GET";
			httpWebRequest.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes("YOUR_USERNAME:YOUR_PASSWORD"));
			var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
			DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(FilterKopf[]));
			var filterKoepfe = (FilterKopf[])serializer.ReadObject(httpResponse.GetResponseStream());
			return filterKoepfe;
		}
    }
	[DataContract]
	internal class FilterKopf
	{
		[DataMember]
		public string id = string.Empty;
		[DataMember]
		public string name = string.Empty;
		[DataMember]
		public string description = string.Empty;
		[DataMember]
		public string jql = string.Empty;
	}
