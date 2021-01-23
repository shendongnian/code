	public class RootObject {
		[JsonProperty(PropertyName = "http://www.example.com/extension/powered-by")]
		public TinCanObject tinCanObject {get;set;}
	}
	public class TinCanObject {
		public string name {get;set;}
		public string home {get;set;}
		public string version {get;set;}
	}
------
	RootObject rootObject = new RootObject();
	rootObject.tinCanObject = new TinCanObject();
	rootObject.tinCanObject.name = "Tin Can Engine";
	rootObject.tinCanObject.home = "../lrs-lms/lrs-for-lmss-home/";
	rootObject.tinCanObject.version = "2012.1.0.5039b";
	string result = JsonConvert.SerializeObject(rootObject);
