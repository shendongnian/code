    public static class MyDataWorker
    {
        public static MyData ReadMyData()
        {
            XmlSerializer reader = new XmlSerializer(typeof(MyData));
            System.IO.StreamReader file = new System.IO.StreamReader("MyData.xml");
            MyData data = new MyData();
            data = (MyData)reader.Deserialize(file);
            file.Close();
            return data;
        }
        public static void WriteMyData(MyData data)
        {
            XmlSerializer writer = new XmlSerializer(typeof(MyData));
            System.IO.StreamWriter file = new System.IO.StreamWriter("MyData.xml");
            writer.Serialize(file, data);
            file.Close();
        }
    }
