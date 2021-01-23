    using (StreamReader sr = new StreamReader(FILENAME))
     {
        string s = sr.ReadToEnd();
        dynamic jsonObject = JObject.Parse(s);
        var emp = v.Where(x => x["ID"].ToString() ==empmodl.ID.ToString()).ToList();
    	
    	//do the modifications here
    	//write the contents to the file by using this
    	JsonConvert.SerializeObject(jsonObject);
      }
