     private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists("data.xml"))
            {
                using (FileStream read = new FileStream("data.xml", FileMode.Open, FileAccess.Read, FileShare.Read))
               {
                    XmlSerializer xs = new XmlSerializer(typeof(Information))
                    Information info = (Information)xs.Deserialize(read);
    
                     data1.Text = info.Data1;
                     data2.Text = info.Data2;
                     data4.Text = info.Data3;
                     data4.Text = info.Data4;
              }
            }
        }
    class SaveXML
    {
        public static void SaveData(object obj, string filename)
        {
            using(TextWriter writer = new StreamWriter(filename))
            {
                XmlSerializer sr = new XmlSerializer(obj.GetType());
    
                sr.Serialize(writer, obj);
            }     
        }
    }
