    class URLMap : EntityTypeConfiguration<URL>
    {
        public URLMap()
        {
            Map(m =>
            {
                m.Properties(p => new {p.ID, p.Project});
                m.ToTable("Project_URLs");
            });
            Map(m =>
            {
                m.Properties(p => new
                {
                    p.ID,
                    // all other properties separated by ,
                });
                m.ToTable("URLs");
            });
            HasKey(p => p.ID);
        }
    }
