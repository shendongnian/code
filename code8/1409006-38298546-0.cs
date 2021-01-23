    public void SaveData()
    {
        if (!Directory.Exists("Saves"))
            Directory.CreateDirectory("Saves");
            
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream saveFile = File.Create("Saves/save.binary");
        LocalCopyOfData = PlayerState.Instance.localPlayerData;
        formatter.Serialize(saveFile, LocalCopyOfData);
        saveFile.Close();
    }
    public void LoadData()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream saveFile = File.Open("Saves/save.binary", FileMode.Open);
        LocalCopyOfData = (PlayerStatistics)formatter.Deserialize(saveFile);
        saveFile.Close();
    }
