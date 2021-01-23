    using System.IO;
    using System.Xml.Linq;
    private void SeparateNames(string txt)
    {
        StreamWriter sw = new StreamWriter("yourfile.txt");
        foreach (var line in txt.Split('\r'))
        {
            XElement el = XElement.Parse(line);
            sw.WriteLine(el.Attribute("name").Value);
        }
        sw.Close();
    }
