    class Program
    {
        static void Main(string[] args)
        {
            string sXml = @"<story id=""485432424"">
                    <link type=""html"">http://www.npr.org/2016/07/10/485432424/with-administrative-corruption-in-afghanistan-u-s-troops-presence-won-t-make-any?ft=nprml&amp;f=1149</link>
                    <link type=""api"">http://api.npr.org/query?id=485432424&amp;apiKey=MDIxNjY4ODAwMDE0NTAxMjAwODQ4ZTA1Nw000</link>
                    <link type=""short"">http://n.pr/29EFodu</link>
                </story>";
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.LoadXml(sXml);
            Story story = new Story(doc.DocumentElement);
            Console.Write(story.ToString());
            Console.ReadLine();
        }
    }
    class Story
    {
        public Link Link { get; set; }
        public Story(System.Xml.XmlNode nStory)
        {
            this.Link = new Link();
            foreach (System.Xml.XmlNode nLink in nStory.ChildNodes)
            {
                if (nLink.NodeType == System.Xml.XmlNodeType.Element)
                {
                    this.Link.AddLink(nLink);
                }
            }
        }
        public override string ToString()
        {
            return new StringBuilder().Append(
                "Html: ").Append(this.Link.Html).Append(Environment.NewLine).Append(
                "Api: ").Append(this.Link.Api).Append(Environment.NewLine).Append(
                "Short: ").Append(this.Link.Short).Append(Environment.NewLine).ToString();
        }
    }
    class Link
    {
        public string Html { get; set; }
        public string Api { get; set; }
        public string Short { get; set; }
        public Link()
        {
        }
        public void AddLink(System.Xml.XmlNode nLink)
        {
            switch (nLink.Attributes["type"].Value)
            {
                case "html":
                    Html = nLink.InnerText;
                    break;
                case "api":
                    Api = nLink.InnerText;
                    break;
                case "short":
                    Short = nLink.InnerText;
                    break;
            }
        }
    }
