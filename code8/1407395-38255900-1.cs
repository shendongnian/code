    public class ConversationConfig : EntityTypeConfiguration<Conversation>
    {
        public ConversationConfig()
        {
            HasKey(c => c.ID);
            HasRequired(c => c.SenderUser).WithMany(u => u.Conversations)
                              .HasForeignKey(c => c.SenderUserID).WillCascadeOnDelete(true);
            HasRequired(c => c.RecipientUser).WithMany()
                              .HasForeignKey(c => c.RecipientUserID).WillCascadeOnDelete(false);
            HasMany(c => c.Messages).WithRequired(x => x.Conversation)
                          .HasForeignKey(x => x.ConversationID);
        }
    }
