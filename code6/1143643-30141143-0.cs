    public class projects
    {
        public List<sites> siteInfo { get; set; }
        ...
        public projects (string project_name, string project_id, string site_id)
        {
            this.project_name = project_name;
            this.project_id = project_id;
            this.site_id = site_id;
            this.siteInfo = new List<sites>(); // You can add stuff to the List here if you want, or you can just initialize it.
        }
    }
