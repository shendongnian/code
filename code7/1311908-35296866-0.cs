    public class Template
    {
    	public int Id { get; set; }
    	public virtual XmlDoc XmlDoc { get; set; }
    	public virtual OtherXmlDoc OtherXmlDoc { get; set; }
    }
    
    public class XmlDoc
    {
    	public int Id { get; set; }
    	[Required]
    	public string RawXml { get; set; }
    	public virtual Template Template { get; set; }
    }
    
    public class OtherXmlDoc
    {
    	public int Id { get; set; }
    	[Required]
    	public string RawXml { get; set; }
    	public virtual Template Template { get; set; }
    }
    private void ConfigureTemplates(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Template>()
            .HasRequired<XmlDoc>(t => t.XmlDoc)
            .WithRequiredPrincipal(d => d.Template)
            .WillCascadeOnDelete(true);
        modelBuilder.Entity<Template>()
            .HasOptional<OtherXmlDoc>(t => t.OtherXmlDoc)
            .WithOptionalPrincipal(d => d.Template)
            .WillCascadeOnDelete(true);
    }
