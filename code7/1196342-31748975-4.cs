    public class bar
    {
        var _c = "foo";
        public string a {get;set;}
        public string b {get;set;}
        public string c {
           get {return _c;} 
           set {_c = value;}
        }
    }
