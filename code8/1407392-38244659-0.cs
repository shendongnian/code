    public class User
    {
      public User()
      {
       Conversations = new List<Conversation>();
       CurrentUserConversations = new List<Conversation>();
       }
    
       public Guid Id { get; set; }
       public string Name { get; set; }
       public bool Active { get; set; }
       public string UserName { get; set; }
       public ICollection<Conversation> Conversations { get; set; }
       public ICollection<Conversation> CurrentUserConversations { get; set; }
    }
    
    public class Conversation
    {
     public Conversation()
     {
      Messages = new List<Message>();
     }
     public Guid ID { get; set; }
     public User RecipientUser { get; set; }
     public Guid SenderUserId { get; set; }
     public User CurrentUser { get; set; }
     public Guid? CurrentUserId { get; set; }
     public ICollection<Message> Messages { get; set; }
    }
    
    public class UserConfig : EntityTypeConfiguration<User>
    {
     public UserConfig()
     {
      HasMany(x => x.Conversations).WithRequired(x => x.RecipientUser).HasForeignKey(x => x.SenderUserId);
      HasMany(x => x.CurrentUserConversations).WithOptional(x => x.CurrentUser).HasForeignKey(x => x.CurrentUserId);
     }
    }
