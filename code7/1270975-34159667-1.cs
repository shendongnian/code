    public class ActionGroup
    {
        public string type;
        public string text;
        Source source;
        public ActionGroup()
        {
            this.type = string.Empty;
            this.text = string.Empty;
            this.source = new Source();
        }
        public Source Source
        {
            get { return source; }
            set { source = value; }
        }
    }
