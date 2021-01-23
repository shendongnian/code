    public class tStore
    {
        public virtual ICollection<tSectionForwardSelling> SectioNForwardSellings { get; set; }
        public virtual ICollection<tSectionSqft> SectionSqfts { get; set; }        
    }
    public class tSectionForwardSelling
    {
        public virtual tStore Store { get; set; }
        public virtual tSection Section { get; set; }
    }
    public class tSectionSqft
    {
        public virtual tStore Store { get; set; }
        public virtual tSection Section { get; set; }
    }
    public class tSection
    {
        public virtual ICollection<tSectionForwardSelling> SectioNForwardSellings { get; set; }
        public virtual ICollection<tSectionSqft> SectionSqfts { get; set; }   
    }
    public void Method(tStore store)
    {
        var storeSectionName = Context.Sections.Where(s => s.SectionSqfts.Where(sqft => sqft.Store == store).Any()).FirstOrDefault().Section_Name;
    }
