	using System.Net;
	string requestUrl = String.Format("http://content.guardianapis.com/search?q=putin&api-key=6392a258-3c53-4e76-87ec-e9092356fa74");
	string json = new WebClient().DownloadString(requestUrl);
	var jss = new JavaScriptSerializer();
	var dict = jss.Deserialize<Dictionary<string, dynamic>>(json.ToString());
	object result = dict["results"];
	foreach (object items in result as System.Collections.ArrayList)
	{
		Dictionary<string, object> item = (Dictionary<string, object>)items;
		string type = item["type"];
		string sectionId = item["sectionId"];
		...
		...
		...
		//or
		//foreach(object item in items) { }
	} 
