    //get the lines from the file.
    var lines = System.IO.File.ReadAllLines("list_city.json");
    //format the lines into a proper JSON array
    string jsonArray = string.Format("[{0}]", string.Join(",", lines));
    var result = JsonConvert.DeserializeObject<List<Rootobject>>(jsonArray);
