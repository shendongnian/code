    [Serializable()]
    public class CLevel
    {
        public string Info { get; set; }
    }
    [Serializable()]
    public class CDatafile
    {
        public List<CLevel> LevelList { get; set; }
        public CDatafile()
        {
            LevelList = new List<CLevel>();
        }
    }
    public class DataManager
    {
        private string FileName = "Data.xml";
        public CDatafile Datafile { get; set; }
        public DataManager()
        {
            Datafile = new CDatafile();
        }
        // Load file
        public void LoadFile()
        {
            if (System.IO.File.Exists(FileName))
            {
                System.IO.StreamReader srReader = System.IO.File.OpenText(FileName);
                Type tType = Datafile.GetType();
                System.Xml.Serialization.XmlSerializer xsSerializer = new System.Xml.Serialization.XmlSerializer(tType);
                object oData = xsSerializer.Deserialize(srReader);
                Datafile = (CDatafile)oData;
                srReader.Close();
            }
        }
        // Save file
        public void SaveFile()
        {
            System.IO.StreamWriter swWriter = System.IO.File.CreateText(FileName);
            Type tType = Datafile.GetType();
            if (tType.IsSerializable)
            {
                System.Xml.Serialization.XmlSerializer xsSerializer = new System.Xml.Serialization.XmlSerializer(tType);
                xsSerializer.Serialize(swWriter, Datafile);
                swWriter.Close();
            }
        }
