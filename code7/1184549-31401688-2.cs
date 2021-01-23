	var json = "{\"1_3_g1_text\":\"11\"}
				{\"1_3_g2_text\":\"\"}
				{\"6_12_g2_text\":\"test\"}
				{\"6_12_g3_text\":\"\"}
				{\"1_17_g1_text\":\"works\"}
				{\"5_19_g2_text\":\"submitted\"}
				{\"5_19_g3_text\":\"2\"}";
				
	var jsons = json.Split('{', '}').Where(x => !string.IsNullOrWhiteSpace(x));
	var concatenatedJson = string.Format("{{{0}}}", string.Join(",", jsons));
	var intermidiateDict = JsonConvert.DeserializeObject<Dictionary<string, string>>(
																		  concatenatedJson);
	
	var actualDict = intermidiateDict.Where(x => 
	{ 
		var isNullOrEmpty = string.IsNullOrEmpty(x.Value);
		int value;
		return !isNullOrEmpty && int.TryParse(x.Value, out value);
	}).ToDictionary(x => x.Key, x => x.Value);
