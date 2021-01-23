    //using System.Collections.Generic;
    
    public class Models
    {
        public List<Model> models { get; set; }
    }
    public class Model
    {
        public string name { get; set; }
        public List<FirmwareFile> firmwarefiles { get; set; }
    }
    public class FirmwareFile
    {
        public string filename { get; set; }
        public Version version { get; set; }
        public int datecode { get; set; }
    }
