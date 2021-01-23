    // not tested
    class CensusDataSet
    {
        [JsonProperty("c_dataset")]
        public string[] CDataset { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
    }
    class CensusData
    {
 
        [JsonProperty("dataset")]
        public CensusDataSet[] DataSets { get; set; }
    }
    ...
    var data = Newtonsoft.Json.JsonConvert.DeserializeObject<CensusData>(content);
    foreach (var dataSet in data.DataSets) ...
