    public class Player
    {
        public int PlayerId { get; set; }
        protected string Name { get; set; }
    
        public class PlayerConfiguration : EntityTypeConfiguration<Player>
        {
            public PlayerConfiguration()
            {
                Property(b => b.Name);
            }
        }
    }
