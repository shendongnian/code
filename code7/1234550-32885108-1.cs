    [XmlRoot("Function")]
    public class MyResponse
    {
        [XmlIgnore]
        public List<Setting> Settings { get; set; }
        /// <summary>
        /// Proxy property to convert Settings to an alternating sequence of Cmd / Status elements.
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [XmlAnyElement]
        public XElement[] Elements 
        {
            get
            {
                if (Settings == null)
                    return null;
                return Settings.SelectMany(s => new[] { new XElement("Cmd", s.Cmd), new XElement("Status", s.Status) }).ToArray();
            }
            set
            {
                if (value == null)
                    Settings = null;
                else
                    Settings = value.Where(e => e.Name == "Cmd").Zip(value.Where(e => e.Name == "Status"), (cmd, status) => new Setting { Cmd = (int)cmd, Status = (int)status }).ToList();
            }
        }
    }
