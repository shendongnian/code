    public class Recommendation
    {
        [XmlArray("screenshot-urls")]
        [XmlArrayItem("screenshots")]
        public TopAppScreenshots[] Screenshoturls { get; set; }
        public class TopAppScreenshots
        {
            [XmlElement("screenshot")]
            public TopAppScreenshot[] Screenshot { get; set; }
            [XmlAttribute("d")]
            public string Dimension { get; set; }
            public class TopAppScreenshot
            {
                [XmlAttribute("w")]
                public string Width { get; set; }
                [XmlAttribute("h")]
                public string Height { get; set; }
                [XmlAttribute("orientation")]
                public string Orientation { get; set; }
                [XmlText]
                public string ScreenshotUrl { get; set; }
            }
        }
    }
