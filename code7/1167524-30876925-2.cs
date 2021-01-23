    public class ChatContext : DbContext
    {
        public static DbSet<User> Users { get; set; }
        public DbSet<Conversation> Conversations { get; set; }
    }
