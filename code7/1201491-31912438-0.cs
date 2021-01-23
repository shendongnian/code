    [SitecoreType(TemplateId = DCP.Resources.TemplateIDS.CategoryTemplateID, AutoMap = true)]
    public class ContentCategory : SCItem
    {
       [SitecoreField(FieldName = "Category name")]
       public virtual string CategoryName { get; set; }
       [SitecoreField(FieldName = "Category icon")]
       public virtual Image CategoryICON { get; set; }
    
       [SitecoreField(FieldName = "text")]
       public virtual string Text { get; set; }
    }
