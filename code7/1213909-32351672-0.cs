    public class JsTreeModel
    {
        public string id { get; set; }
        public string parent { get; set; } 
        public string text { get; set; }
        public bool children { get; set; } // if node has sub-nodes set true or not set false
    }
