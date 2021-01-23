    var list = new List<CacheItem<ReadabilitySettings>>();
    list.Add(new CacheItem<ReadabilitySettings>() { Key = "key1", Value = new ReadabilitySettings() { FontName = "FontName", FontSize = ReadabilitySettings.FontSizes.Large, IsInverted = false, ReadabilityEnabled = true } });
    
    var json = JsonConvert.SerializeObject(list);
    var list2 = JsonConvert.DeserializeObject<List<CacheItem<object>>>(json);
    var settings = JsonConvert.DeserializeObject<ReadabilitySettings>(list2.First().Value.ToString());
