    public class MyObject {
        public string url { get; set; }
        public bool case { get; set; }
    }
    public IEnumerable<MyObject> process(List<string> listOfUrls) {
    	foreach(var item in listofUrls) {
    		yield return new MyObject {
    			url = item;
    			case = false;
    		}
    	}
    }
