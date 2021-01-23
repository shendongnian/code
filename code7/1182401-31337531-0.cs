    public class ArcMapping : EntityTypeConfiguration<Arc>
    {
        public ArcMapping()
        {
            Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Arc");
            });
        }
    }
    public class NodeMapping : EntityTypeConfiguration<Node>
    {
        public NodeMapping()
        {
            HasKey(t => t.SomeId);
            Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Node");
            });
        }
    }
    public class ParentArcMapping : EntityTypeConfiguration<ParentArc>
    {
        public ParentArcMapping()
        {
            HasKey(t => t.ArcId);
            HasRequired(p => p.StartNode).WithMany().HasForeignKey(p => p.StartNodeId).WillCascadeOnDelete(false);
            HasRequired(p => p.EndNode).WithMany().HasForeignKey(p => p.EndNodeId).WillCascadeOnDelete(false);
        }
    }
