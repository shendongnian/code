    [XmlRoot(ElementName="VISUALFOLDER")]
    public class VISUALFOLDER {
    	[XmlAttribute(AttributeName="Date")]
    	public string Date { get; set; }
    	[XmlAttribute(AttributeName="ByUser")]
    	public string ByUser { get; set; }
    	[XmlAttribute(AttributeName="Name")]
    	public string Name { get; set; }
    	[XmlAttribute(AttributeName="Type")]
    	public string Type { get; set; }
    	[XmlAttribute(AttributeName="StartView")]
    	public string StartView { get; set; }
    	[XmlAttribute(AttributeName="ScreenOffset")]
    	public string ScreenOffset { get; set; }
    }
    
    [XmlRoot(ElementName="VISUALTABSHEET")]
    public class VISUALTABSHEET {
    	[XmlAttribute(AttributeName="Date")]
    	public string Date { get; set; }
    	[XmlAttribute(AttributeName="Name")]
    	public string Name { get; set; }
    	[XmlAttribute(AttributeName="Type")]
    	public string Type { get; set; }
    }
    
    [XmlRoot(ElementName="VISUALINDEXFIELD")]
    public class VISUALINDEXFIELD {
    	[XmlAttribute(AttributeName="Date")]
    	public string Date { get; set; }
    	[XmlAttribute(AttributeName="Name")]
    	public string Name { get; set; }
    }
    
    [XmlRoot(ElementName="INDEXFIELD")]
    public class INDEXFIELD {
    	[XmlElement(ElementName="VISUALINDEXFIELD")]
    	public VISUALINDEXFIELD VISUALINDEXFIELD { get; set; }
    	[XmlAttribute(AttributeName="Date")]
    	public string Date { get; set; }
    	[XmlAttribute(AttributeName="Name")]
    	public string Name { get; set; }
    }
    
    [XmlRoot(ElementName="TABSHEET")]
    public class TABSHEET {
    	[XmlElement(ElementName="VISUALTABSHEET")]
    	public VISUALTABSHEET VISUALTABSHEET { get; set; }
    	[XmlElement(ElementName="INDEXFIELD")]
    	public List<INDEXFIELD> INDEXFIELD { get; set; }
    	[XmlAttribute(AttributeName="Date")]
    	public string Date { get; set; }
    	[XmlAttribute(AttributeName="Name")]
    	public string Name { get; set; }
    	[XmlAttribute(AttributeName="Type")]
    	public string Type { get; set; }
    	[XmlElement(ElementName="DOCUMENT")]
    	public List<DOCUMENT> DOCUMENT { get; set; }
    	[XmlAttribute(AttributeName="Data")]
    	public string Data { get; set; }
    	[XmlAttribute(AttributeName="SeqNo")]
    	public string SeqNo { get; set; }
    	[XmlAttribute(AttributeName="Title")]
    	public string Title { get; set; }
    	[XmlAttribute(AttributeName="Password")]
    	public string Password { get; set; }
    }
    
    [XmlRoot(ElementName="VISUALDOCUMENT")]
    public class VISUALDOCUMENT {
    	[XmlAttribute(AttributeName="Date")]
    	public string Date { get; set; }
    	[XmlAttribute(AttributeName="Name")]
    	public string Name { get; set; }
    	[XmlAttribute(AttributeName="Type")]
    	public string Type { get; set; }
    	[XmlAttribute(AttributeName="Height")]
    	public string Height { get; set; }
    	[XmlAttribute(AttributeName="Width")]
    	public string Width { get; set; }
    }
    
    [XmlRoot(ElementName="DOCUMENT")]
    public class DOCUMENT {
    	[XmlElement(ElementName="VISUALDOCUMENT")]
    	public VISUALDOCUMENT VISUALDOCUMENT { get; set; }
    	[XmlAttribute(AttributeName="Date")]
    	public string Date { get; set; }
    	[XmlAttribute(AttributeName="Name")]
    	public string Name { get; set; }
    	[XmlAttribute(AttributeName="Type")]
    	public string Type { get; set; }
    	[XmlAttribute(AttributeName="Data")]
    	public string Data { get; set; }
    	[XmlAttribute(AttributeName="FileName")]
    	public string FileName { get; set; }
    	[XmlAttribute(AttributeName="FileOffset")]
    	public string FileOffset { get; set; }
    	[XmlAttribute(AttributeName="FileSize")]
    	public string FileSize { get; set; }
    	[XmlAttribute(AttributeName="BinaryType")]
    	public string BinaryType { get; set; }
    }
    
    [XmlRoot(ElementName="FOLDER")]
    public class FOLDER {
    	[XmlElement(ElementName="VISUALFOLDER")]
    	public VISUALFOLDER VISUALFOLDER { get; set; }
    	[XmlElement(ElementName="TABSHEET")]
    	public List<TABSHEET> TABSHEET { get; set; }
    	[XmlAttribute(AttributeName="Date")]
    	public string Date { get; set; }
    	[XmlAttribute(AttributeName="ByUser")]
    	public string ByUser { get; set; }
    	[XmlAttribute(AttributeName="Name")]
    	public string Name { get; set; }
    	[XmlAttribute(AttributeName="Type")]
    	public string Type { get; set; }
    	[XmlAttribute(AttributeName="MemberOf")]
    	public string MemberOf { get; set; }
    }
    
    [XmlRoot(ElementName="FOLDERS")]
    public class FOLDERS {
    	[XmlElement(ElementName="FOLDER")]
    	public List<FOLDER> FOLDER { get; set; }
    	[XmlAttribute(AttributeName="Name")]
    	public string Name { get; set; }
    }
