        var startPath = Application.StartupPath;
        string folderName = Path.Combine(startPath, "POI_List");
        System.IO.Directory.CreateDirectory(folderName);
        string fileName = "POI.txt";
        var path = Path.Combine(folderName, fileName);
        List<string> ReadFile = File.ReadAllLines(@"I:\TouristPlace\TouristPlace\bin\Debug\CityList\POI_list.txt", Encoding.GetEncoding("windows-1252")).ToList();
        foreach (string line in ReadFile)
        {
            Dictionary<string, string> cities = new Dictionary<string, string>();
            using (var client = new HttpClient())
            {
                var response = client.GetAsync("https://en.wikipedia.org/w/api.php?action=query&list=geosearch&gsradius=10000&gspage=" + WebUtility.UrlEncode(line) + "&gslimit=500&gsprop=type|name|dim|country|region|globe&format=json").Result;
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content;
                    string responseString = responseContent.ReadAsStringAsync().Result;
                    var obj = JsonConvert.DeserializeObject<RootObject>(responseString).query.geosearch.Select(a => a.title).ToList(); //NulReferanceException error occurd
                    List<string> places = new List<string>();
                    foreach (var item in obj)
                    {
                        places.Add(item);
                    }
                    cities[line] = string.Join(";", places);
                    var output = line + ";" + cities[line];
		    if (!File.Exists(path))
		    {
			File.WriteAllText(path, output); //here is problem
		    }
		    else
		    {
		     	File.AppendAllText(path, output);
		    }
                }
            }
        }
    }
