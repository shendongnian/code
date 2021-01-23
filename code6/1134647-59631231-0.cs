    void SerializeListObject(object sender, EventArgs e)
    {
        string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "sample.txt");
        List<string> list = new List<string>();
        list.Add("Apple");
        list.Add("Banana");
        FileStream fileStream = new FileStream(filePath, FileMode.Create);
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(fileStream, list);
        fileStream.Close();
    }
    void DerializeListObject(object sender, EventArgs e)
    {
        string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "sample.txt");
        FileStream fileStream = new FileStream(filePath, FileMode.Open);
        BinaryFormatter bf = new BinaryFormatter();
        List<string> list = (bf.Deserialize(fileStream) as List<string>);
        Debug.WriteLine("1st Item: " + list[0] + "\n2nd Item: " + list[1]);
        fileStream.Close();
    }
