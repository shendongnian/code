    public class Sequence
    {
        public Point[] SourcePath { get; set; }
    }
    using (FileStream fs = new FileStream(@"D:\youXMLFile.xml", FileMode.Open))
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Sequence[]));
        var data=(Sequence[]) serializer.Deserialize(fs);
        List<string> list = new List<string>();
        foreach(var item in data)
        {
            list.Add(string.Join(",", item.SourcePath));
        }
        File.WriteAllLines("D:\\csvFile.csv", list);
    }
