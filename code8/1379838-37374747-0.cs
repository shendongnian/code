    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
            }
     
        }
        public class Map
        {
            public int[,] map { get; set; }
                
            public int[,] LoadLevelData(string filename)
            {
                using (XmlTextReader reader = new XmlTextReader(filename))
               {
                   XmlSerializer xs = new XmlSerializer(typeof(Map));
                   Map map = (Map)xs.Deserialize(reader);
                   this.map = map.map;
                   return map.map;
                }
            }
            public void SaveLevelData(string filename)
            {
                using (StreamWriter writer = new StreamWriter(filename))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Map));
                    serializer.Serialize(writer, this.map);
                    writer.Flush();
                    writer.Close();
                    writer.Dispose();
                }
            }
        }
    }
