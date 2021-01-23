     public class FileMap : EntityTypeConfiguration<FileContent>
     {
        public FileMap()
       {
        ToTable("FileContent");
        HasKey(t => t.Id);
      
        WithRequired(t => t.FileModel)
            .HasOptional(t => t.FileContent)
        
       }
    }  
