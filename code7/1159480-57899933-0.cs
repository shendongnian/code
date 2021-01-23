    class MyClass
    {
        [PlistName("genre")]
        public string Genre { get; set; }
        [PlistName("bundleVersion")]
        public string BundleVersion { get; set; }
        [PlistName("itemName")]
        public string ItemName { get; set; }
        [PlistName("kind")]
        public string Kind { get; set; }
        [PlistName("playlistName")]
        public string PlaylistName { get; set; }
        [PlistName("softwareIconNeedsShine")]
        public bool SoftwareIconNeedsShine { get; set; }
        [PlistName("softwareVersionBundleId")]
        public string SoftwareVersionBundleId { get; set; }
    }
    var byteArray = Encoding.ASCII.GetBytes(YourPlist.plist);
    var stream = new MemoryStream(byteArray);
    var node = PList.Load(stream);
    var deserializer = new Deserializer()
    deserializer.Deserialize<MyClass>(rootNode);
