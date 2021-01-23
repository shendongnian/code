    class URLMap : EntityTypeConfiguration<URL>
    {
        public URLMap()
        {
            Map(m =>
            {
                m.Properties(p => new {p.Project});
                m.ToTable("Project_URLs");
            });
        }
    }
