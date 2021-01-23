	public static XmlDocument xml = new XmlDocument();
	    
	static void Main(string[] args)
	{
	    xml.Load("config.xml");
		List<string> url = new List<string>();
		int count = xml.GetElementsByTagName("url").Count;
		for (int i = 0; i < count; ++i)
		{
		    url.Add(xml.GetElementsByTagName("url")[i].InnerText);
		    Url = url[i];               
			test(Url);
		}
	                
	}
	private static void test(string url)
	{
	    string listFile = "ListOfSites";
		string outCsvFile = string.Format(@"C:\\testFile\\{0}.csv", testFile + DateTime.Now.ToString("_yyyyMMdd HHmms"));
		using (FileStream fs = new FileStream(outCsvFile, FileMode.Append, FileAccess.Write))           
		{
			using (StreamWriter file = new StreamWriter(fs))
			{
				file.WriteLine("ProjectTitle,PublishStatus,Type,NumberOfSUsers,URL");
		    foreach(WS.ProjectData proj in pr.Distinct(new ProjectEqualityComparer()))
		        {
		            file.WriteLine("{0},\"{1}\",{2},{3},{4}",
		            proj.ProjectTitle,                               
		            proj.PublishStatus,                               
		            proj.type,
		            proj.userIDs.Length.ToString(NumberFormatInfo.InvariantInfo),
		            url);
		        }
			}
		}         
	}
