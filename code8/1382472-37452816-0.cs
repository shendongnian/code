    public class MyJsonResult
    {
        public string name { set; get; }
        public string result { set; get; }
    }
    
    static void Main(string[] args)
    {
        string myJson = "[{ name: 'abc',city: 'dallas'},{ name: 'def',city: 'redmond'},{ name: 'ghi',city: 'bellevue'}]";
    
        JavaScriptSerializer jss = new JavaScriptSerializer();
        List<MyJsonResult> jsonResultList = jss.Deserialize<List<MyJsonResult>>(myJson);
    
        var NameInFirstItem = jsonResultList.FirstOrDefault().name;
    }
