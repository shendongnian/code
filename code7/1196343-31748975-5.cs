    public class bar
        {
            string _c = null;
            public string a {get;set;}
            public string b {get;set;}
            public string c {
               get {return _c ?? "foo";} 
               set {_c = value;}
            }
        }
