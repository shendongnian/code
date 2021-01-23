    private void SaveSettings()
    {            
        var SensorList = new ArrayList();
        foreach(var item in ConfigList.Items)
        {
            SensorList.Add(item);
        }
        Stream stream = File.Open(@"K:\\Setting.myfile", FileMode.Create);
        BinaryFormatter bformatter = new BinaryFormatter();
        bformatter.Serialize(stream, SensorList);
        stream.Close();
    }
