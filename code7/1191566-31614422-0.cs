    public class Book
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public ICollection<Chapter> Chapters { get; set; }
        }
        
        public class Chapter
        {
            public int Id { get; set; }
            public virtual int BookId {get;set;}
            public virtual Book Book {get;set;}
            public string Name { get; set; }
            public string Period { get; set; }
        }
        
         public class ChapterMapping : EntityTypeConfiguration<Chapter>
            {
                public ChapterMapping
                {
                    HasKey(c=> c.Id);
                    Property(c => c.Id).HasDatabaseGeneratedOption(
                        DatabaseGeneratedOption.Identity);
                    HasRequired(c => c.Book).WithMany(b => b.Chapters)
                   .HasForeignKey(c => c.BookId).WillCascadeOnDelete(true);
        
                }
                 
            }
