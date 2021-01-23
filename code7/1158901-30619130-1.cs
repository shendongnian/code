    public class ReferenceData
    {
        public string version { get; set; }
        public List<DataItem> data { get; set; }
    }
    public class DataItem
    {	
		[JsonExtensionData]
		public IDictionary<string, object> item { get; set; }
    }
    // ...
    var referenceData = new ReferenceData {
	    version = "1.0",
		data = new List<DataItem> {
			new DataItem {
				item = new Dictionary<string, object> {
					{"1", "2"},
				    {"3", "4"}
				}
			},
			new DataItem {
				item = new Dictionary<string, object> {
					{"5", "8"},
				    {"6", "7"}
				}
			}
		}
	};
		    
    Console.WriteLine(JsonConvert.SerializeObject(referenceData));
