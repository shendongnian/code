    public class tableAConfig:BaseEntity<tableA>
    {
        public tableAConfig()
        {
            HasKey(p=>p.tAId);
            
            HasOptional(p => p.tableB )
                .WithRequired( p => p.tableA );
        }
