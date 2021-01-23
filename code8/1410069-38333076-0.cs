    // read in the existing list
    // IMPORTANT - if this is the first time and the file doesn't exist, then
    // you need to initialise itemList = new List<Item>();
    json = File.ReadAllText(filePath);
    var itemList = JsonConvert.DeserializeObject<List<Item>>(json);
    
    // add a new item
    itemList.Add(newItem);
    
    // serialize the list and write it out again
    string json = JsonConvert.SerializeObject(item, Formatting.Indented);
    File.WriteAllText(path,json);
