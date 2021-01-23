    public class BackUpMail
    {
    	public List<BackUp> BackUpItems {get;set;}
    }
    
    public class BackUp
    {
     [XmlAttribute("id")]
     public string ID {get;set}
     
     [XmlElement("foldername")]
     public string FolderName {get;set;}
     
     [XmlElement("backupdate")]
     public DateTime BackupDate {get;set;}
     
     [XmlElement("comment")]
     public string Comment {get;set}
     
     [XmlElement("numberofparts")]
     public string NumberOfParts {get;set}
     
     [XmlElement("lastsucceed")]
     public string LastSucceed {get;set}
    }
