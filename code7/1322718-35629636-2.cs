    public partial class Provider
    {
        //...
        //public virtual Drm Drm { get; set; }
        public virtual ICollection<Drm> Drms { get; set; }
    }
    
    public partial class CustomerSite
    {
        //...
        //public virtual Drm Drm { get; set; }
        public virtual ICollection<Drm> Drms { get; set; }
    }
    
    public partial class DrmType
    {
        //public virtual Drm Drm { get; set; }        
        public virtual ICollection<Drm> Drms { get; set; }
    }
