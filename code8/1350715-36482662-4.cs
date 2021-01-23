    class Model
    {
        public IList<object> stations { get; set; }
    }
    var jsonObject = JsonConvert.DeserializeObject<Model>(localJson);
    foreach (var stationCode in jsonObject.stations)
    {
        ...
    }
