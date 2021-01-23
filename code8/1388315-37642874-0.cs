    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
     
                Car car = new Car();
                car.image = File.ReadAllBytes(@"c:\temp\image1.jpg");
                car.Name = "Temp";
                MemoryStream stream = Serializer.SerializeToStream(car);
                System.IO.File.WriteAllBytes("Temp.Jpeg", stream.ToArray());
                using (var Stream = new MemoryStream(System.IO.File.ReadAllBytes("Temp.Jpeg")))
                {
                    Car cab = (Car)Serializer.DeserializeFromStream(Stream);
                    var imageToSave = Bitmap.FromStream(new MemoryStream( cab.image));
                }
            }
        }
        public class Serializer
        {
            public static MemoryStream SerializeToStream(object o)
            {
                MemoryStream stream = new MemoryStream();
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, o);
                return stream;
            }
            public static object DeserializeFromStream(MemoryStream stream)
            {
                IFormatter formatter = new BinaryFormatter();
                stream.Seek(0, SeekOrigin.Begin);
                object o = formatter.Deserialize(stream);
                return o;
            }
        }
        [Serializable]
        public class Car
        {
            public string Name { get; set; }
            public byte[] image { get; set; }
        }
    }
