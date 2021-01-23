    public class Position
    {
        public double top { get; set; }
        public double left { get; set; }
    }
    public class ActionParams
    {
        public string actionName { get; set; }
        public string itemId { get; set; }
        public string groupId { get; set; }
    }
    public class VisualElement
    {
        public string ID { get; set; }
        public Position position { get; set; }
        public double width { get; set; }
        public double height { get; set; }
        public string label { get; set; }
        public string colour { get; set; }
        public string action { get; set; }
        public ActionParams actionParams { get; set; }
    }
    public class Response
    {
        public string background { get; set; }
        public string theme { get; set; }
        public string name { get; set; }
        public string scriptName { get; set; }
        public List<VisualElement> objects { get; set; }
    }
