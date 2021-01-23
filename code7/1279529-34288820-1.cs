    [DataMember]
    public FileData[] files { get; set; }
    public class FileData {
       [DataMember]
       public string nameFile { get; set;}
       [DataMember]
       public string fileContent { get; set; }
    }
