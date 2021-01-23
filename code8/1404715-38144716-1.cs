    class Question
    {
        public string Title         { get; private set; }
        public List<Option> Options { get; private set; }
        public Question()
        {
        }
        public Question(XmlElement question) : this()
        {
            this.Title   = question["Title"].InnerText;
            this.Options = question.SelectNodes("Options/Option")
                .OfType<XmlElement>()
                .Select(option => new Option(option))
                .ToList();
        }
    }
