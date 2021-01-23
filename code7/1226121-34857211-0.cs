    [SitecoreType(TemplateId = "{YYY}", AutoMap = true)]
    public class RazorRenderClass: BC
    {                      
        [SitecoreChildren(InferType = true, IsLazy = false)]
        public virtual IEnumerable<WB> Children { get; set; }
        [SitecoreChildren(InferType = true, IsLazy = false)]
        public virtual IEnumerable<AAA> AAACh { get; set; }
        [SitecoreChildren(InferType = true, IsLazy = false)]
        public virtual IEnumerable<BBB> BBBCh { get; set; }
    }
