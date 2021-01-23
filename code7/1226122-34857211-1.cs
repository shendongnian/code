    [SitecoreType(TemplateId = "{YYY}", AutoMap = true)]
    public class RazorRenderClass: BC
    {                      
        [SitecoreChildren(InferType = true)]
        public virtual IEnumerable<WB> Children { get; set; }
    }
