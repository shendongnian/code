    [System.AttributeUsage(System.AttributeTargets.All)]
    public class Display : System.Attribute
    {
        private string _name;
        public Display(string name)
        { _name = name; }
        public string GetName()
        { return _name; }
    }
