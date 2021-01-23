    public partial class partTerminal
    {
    	[XmlChoiceIdentifier("TerminalType")]
        [XmlElement("round")]
        [XmlElement("hf")]
        [XmlElement("box")]
        public partTerminalType Type { get; set; }
    	
    	[XmlIgnore]
       	public TerminalChoiceType TerminalType { get; set; }
    }
