    [Serializable]
    [XmlType("InkZoneProfile")]
    public class xmldata //Class to receive items list
    {
        [XmlIgnore]
        public string xml_filename { get; set; }
        [XmlAttribute("Separation")]
        public string colorname { get; set; }
        [XmlAttribute("ZoneSettingsX")]
        public string colorvalues { get; set; }
    }
    FullList.Add(new xmldata { xml_filename = @"D:\File_One", colorname = "Red", colorvalues = "#FF0000" });
    FullList.Add(new xmldata { xml_filename = @"D:\File_One", colorname = "Blue", colorvalues = "#0000FF" });
    FullList.Add(new xmldata { xml_filename = @"D:\File_Two", colorname = "Black", colorvalues = "#000000" });
    FullList.Add(new xmldata { xml_filename = @"D:\File_Two", colorname = "White", colorvalues = "#FFFFFF" });
    Dictionary<string, List<xmldata>> xmlFiles = new Dictionary<string, List<xmldata>>();
    foreach (var item in FullList)
    {
        if (!xmlFiles.ContainsKey(item.xml_filename)) xmlFiles[item.xml_filename] = new List<xmldata>();
        xmlFiles[item.xml_filename].Add(item);
    }
    foreach (var i in xmlFiles)
    {
        string yourXMLFileName = i.Key;
        List<xmldata> xmlDataOfThisFile = i.Value;
        Console.WriteLine(yourXMLFileName);
        try
        {
            using (FileStream fs = new FileStream(yourXMLFileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<xmldata>));
                serializer.Serialize(fs, FullList);
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.InnerException);
        }
    }
