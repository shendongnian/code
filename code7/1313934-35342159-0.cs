    public class Folder
    {
     public int Id{get;set;}
     public virtual ICollection<Letter> Letters{get;set;}
    }
    
    public class Letter
    {
    public int Id{get;set;}
    public int FolderId{get;set;}
    public virtual Folder Folder{get;set;}
    
    }
