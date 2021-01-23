        public class Person
        {
            [Key, Column(Order = 0)]
            public int TenantId { get; set; }
            [Key, Column(Order = 1)]
            public int PersonId { get; set; }
            public string Name { get; set; }
            public virtual ICollection<ProjectPerson> ProjectPeople { get; set; }
        }
        public class Project
        {
            [Key, Column(Order = 0)]
            public int TenantId { get; set; }
            [Key, Column( Order = 1 )]
            public int ProjectId { get; set; }
            public string Name { get; set; }
            public virtual ICollection<ProjectPerson> ProjectPeople { get; set; }
        }
        public class ProjectPerson
        {
            [Key, Column( Order = 0 )]
            public int TentantId { get; set; }
            [Key, Column( Order = 1 )]
            public int ProjectId { get; set; }
            [Key, Column( Order = 2 )]
            public int PersonId { get; set; }
            public DateTime AddedDate { get; set; }
            public virtual Project Project { get; set; }
            public virtual Person Person { get; set; }
        }
        protected override void OnModelCreating( DbModelBuilder modelBuilder )
        {
            base.OnModelCreating( modelBuilder );
            modelBuilder.Entity<Project>()
                .HasMany(pr => pr.ProjectPeople )
                .WithRequired( pp => pp.Project )
                .HasForeignKey( pp => new { pp.TentantId, pp.ProjectId } );
            modelBuilder.Entity<Person>()
                .HasMany( pe => pe.ProjectPeople )
                .WithRequired( pp => pp.Person )
                .HasForeignKey( pp => new { pp.TentantId, pp.PersonId } );
        }
