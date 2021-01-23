      public class FileModel
    {
     [Key, ForeignKey("FileContent")]
    public string Id { get; set; }
    public string Name { get; set; }
    public string FileContentId { get; set; }
    public string Url { get; set; }
    public string CreatedById { get; set; }
    public DateTime CreatedOn { get; set; }
    public virtual ICollection<FileTable> FileTables { get; set; }
    public virtual User CreatedBy { get; set; }
    public virtual FileContent FileContent { get; set; }
     }
      public class FileContent
     {
       public string Id { get; set; }
       public byte[] Contents { get; set; }
       public virtual FileModel FileModel { get; set; }   
      }
   
