        [XmlIgnore]
        public List<DateTime> Times { get; set; }
        [XmlElement(ElementName = "Times")]
        public string [] TimesString
        {
            get
            {
                return Times == null ? null : Times.Select(t => RemoveTimeZone(t)).ToArray();
            }
            set
            {
                if (value == null)
                    return;
                (Times = Times ?? new List<DateTime>(value.Length)).AddRange(value.Select(s => ConvertToDate(s)));
            }
        }
