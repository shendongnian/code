    public static Dictionary<int, Tuple<string, int>> parseJsonIntoDictionary(string jsonFile) {
  		Dictionary<int, Tuple<string, int>> unitDictionary = new Dictionary<int,Tuple<string,int>>();
		var json = System.IO.File.ReadAllText(jsonFile);
		var units = JArray.Parse(json);
		foreach (JToken unit in units) {
			JProperty property = ((JObject)unit).Properties().ToArray()[0];
			int unitID = Convert.ToInt32(property.Name);
			Tuple<string,int> tempTuple = new Tuple<string,int>(Convert.ToString(unit[property.Name]["unit_type"]),Convert.ToInt32(unit[property.Name]["customer_id"]));
			unitDictionary[unitID] = tempTuple;
		}
		return unitDictionary;
	}
