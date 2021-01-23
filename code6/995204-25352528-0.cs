    using (FileStream stream = new FileStream(myXmlFileName, FileMode.Open, FileAccess.Read))
    {
        using (XmlTextReader textReader = new XmlTextReader(stream))
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(MyItemList));
            comboBox1.DataSource = xmlSerializer.Deserialize(textReader);
        }
    }
