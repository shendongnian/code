    [XmlRoot("LockerBank")]
    public class TestBank
    {
        public TestBank()
        {
            TerminalSize = 4;
        }
        [XmlArray(ElementName = "ColumnList")]
        [XmlArrayItem(Type = typeof(LockerColumnLayout), ElementName = "LockersColumn", IsNullable = true)]
        [XmlArrayItem(Type = typeof(SectionLayout), ElementName = "Section", IsNullable = true)]
        public List<object> LockerAndSectionLayouts { get; set; }
        [XmlIgnore]
        public IEnumerable<LockerColumnLayout> Columns { get { return (LockerAndSectionLayouts ?? Enumerable.Empty<object>()).OfType<LockerColumnLayout>(); } }
        [XmlIgnore]
        public IEnumerable<SectionLayout> SectionCollection { get { return (LockerAndSectionLayouts ?? Enumerable.Empty<object>()).OfType<SectionLayout>(); } }
        [XmlAttribute("TerminalSize")]
        public int TerminalSize { get; set; }
    }
