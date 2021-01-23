    var props = typeof(SearchResultRecord).GetProperties().ToDictionary(
    					x => x.Name, 
    					StringComparer.OrdinalIgnoreCase);
    var jss = new JavaScriptSerializer();
    var data = (Dictionary<string,object>)jss.DeserializeObject(json); 
    var cols = ((object[])data["columnNames"]).OfType<string>()
    										  .Select((x,index) => new{index,name=x.Replace(" ","")})
    										  .Where (x => props.ContainsKey(x.name))
    										  .Select (x => new {x.index,prop=props[x.name]}).Dump();
    var rows = ((object[])data["values"]).OfType<object[]>().ToArray();
    
    foreach (var row in rows)
    {
    	var rowdict = cols.Where (c => row[c.index] != null).ToDictionary(c => c.prop.Name, c => row[c.index]);
    	var rowjson = jss.Serialize(rowdict);
    	jss.Deserialize<SearchResultRecord>(rowjson).Dump();
    }
