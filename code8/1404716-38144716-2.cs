    class Option
    {
        public string Title         { get; private set; }
        public bool   IsCorrect     { get; private set; }
        public Option()
        {
        }
        public Option(XmlElement option) : this()
        {
            this.Title = option.InnerText;
            this.IsCorrect = option.GetAttribute("IsCorrect") == "true";
        }
    }
