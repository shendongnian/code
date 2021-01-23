    public class GroupEntry
    {
        [System.Xml.Serialization.XmlIgnore]
        public string a;
        [System.Xml.Serialization.XmlIgnore]
        public string b;
        [System.Xml.Serialization.XmlText]
        public string ab
        {
            get
            {
                return string.Format("{0}:{1}", a, b);
            }
            set
            {
                a = null;
                b = null;
                if (value != null)
                {
                    string[] split = value.Split(':');
                    a = split[0];
                    if (split.Length > 1)
                    {
                        b = split[1];
                    }
                }
            }
        }
    }
