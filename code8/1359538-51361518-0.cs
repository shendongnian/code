    namespace Survey.Models
    {
        public class NetpiperDBcontext : DbContext
        {
            public NetpiperDBcontext();
    
            public virtual DbSet<AnswerOption> AnswerOptions { get; set; }
            public virtual DbSet<Attachment> Attachments { get; set; }
            public virtual DbSet<AttributeIcon> AttributeIcons { get; set; }
        }
    }
