    public class TestClass
    {
        [XmlIgnore]
        public int Amount { get; set; }
        [XmlElement("Amount")]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public XdrTypeWrapper<int> XmlAmount { get { return Amount; } set { Amount = value; } }
        [XmlIgnore]
        public DateTime StartTime { get; set; }
        [XmlElement("StartTime")]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public XdrTypeWrapper<DateTime> XmlStartTime { get { return StartTime; } set { StartTime = value; } }
        [XmlIgnore]
        public double Double { get; set; }
        [XmlElement("Double")]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public XdrTypeWrapper<double> XmlDouble { get { return Double; } set { Double = value; } }
    }
