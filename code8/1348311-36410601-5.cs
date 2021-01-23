    public class Point{
        public string x { get; set; }
        public string y { get; set; }
    }  
    public ActionResult GetData(String request)
    {
        dynamic req = JsonConvert.DeserializeObject<Point>(request);
        string x = req.x; // == val1
        string y = req.y; // == val2 
        //(could be int or whatever you put into val 1 and 2)
    }
