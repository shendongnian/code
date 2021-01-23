    public class Template
    {
    public int Id { get; set; }
    public int XmlDocId{ get; set; }
    
    [ForeignKey("XmlDocId")]
    public virtual XmlDoc XmlDoc { get; set; }
    public int? OtherXmlDocId{ get; set; }
    
    [ForeignKey("OtherXmlDocId")]
    public virtual OtherXmlDoc OtherXmlDoc { get; set; }
    }
