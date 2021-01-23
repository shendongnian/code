    public class ReferenceData
    {
        public string Version { get; set; }
        public List<DataItem> Data { get; set; }
    }
    public class DataItem
    {	
		[JsonExtensionData]
		public IDictionary<string, object> Item { get; set; }
    }
    // ...
    var referenceData = new ReferenceData {
		Version = "1.0",
		Data = new List<DataItem> {
			new DataItem {
				Item = new Dictionary<string, object> {
					{"1", "2"},
				    {"3", "4"}
				}
			},
			new DataItem {
				Item = new Dictionary<string, object> {
					{"5", "8"},
				    {"6", "7"}
				}
			}
		}
	};
		    
    Console.WriteLine(JsonConvert.SerializeObject(referenceData));
