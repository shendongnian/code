    public class Alternative
    {
        public double confidence { get; set; }
        public string transcript { get; set; }
    }
    public class RootObject{
	    public List<Alternative> Alternatives{get;set;}
    }
    var json = "[{'alternatives':[{'transcript':'some text','confidence':0.77053386}]},{'alternatives':[{'transcript':' some other text','confidence':0.84036005}]}]";
    var res = JsonConvert.DeserializeObject<List<RootObject>>(json);
    // output : "some text: some other text"
	Console.WriteLine(res[0].Alternatives[0].transcript + ":" + res[1].Alternatives[0].transcript);
