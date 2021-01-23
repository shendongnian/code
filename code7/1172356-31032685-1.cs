    private void LoadSettings()
    {
        using (Stream stream = File.Open(@"K:\\Setting.myfile", FileMode.Open))
        {
            BinaryFormatter bformatter = new BinaryFormatter();
            var Sensors = (ArrayList)bformatter.Deserialize(stream);
            foreach (var item in Sensors)
            {
                ConfigList.Items.Add(item);
            }
        }
    }
