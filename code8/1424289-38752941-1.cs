    public class File
    {
       public int Id { get; set; }
       public string FileName { get; set; }
           
    }
     public class Folder
       {
         public List<File> Files { get; set; }
       }
