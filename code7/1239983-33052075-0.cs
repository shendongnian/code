    [Serializable]
    public class Asset
    {
        public int Id { get; set; }
        public List<string> Hardware { get; set; }
    }
    ...
    List<Asset> assets = new List<Asset> {new Asset {Id = 1, 
                    Hardware = new List<string> {"mouse", "keyboard"}}};
            
    //serialize
    using (GZipStream zs = new GZipStream(File.Create("compressed_xml.zip"),
                                                CompressionLevel.Fastest))
    {
        XmlSerializer serializer = new XmlSerializer(typeof (List<Asset>));
        serializer.Serialize(zs, assets);
    }
    //deserialize
    using (GZipStream zs = new GZipStream(File.Open("compressed_xml.zip",FileMode.Open), 
                                 CompressionMode.Decompress))
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Asset>));
        assets=(List<Asset>) serializer.Deserialize(zs);
    }
    
