    public class LineItem
    {
        public string Content { get; set; }
        public string ToolTip { get; set; }
        public bool Highlight { get; set; }
        public override string ToString()
        {
            return string.Format("<div {0} title=\"{1}\">{2}</div>" , 
                HighLight==true?"class=\"highlight\"":"" , 
                ToolTip, 
                Content);
        }
    }
    
