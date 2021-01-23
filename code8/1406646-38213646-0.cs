    IEnumerator loadData()
    {
        string fileDir = Application.persistentDataPath;
    
        //Get All Files Path in in the Directory
        string[] filePath = System.IO.Directory.GetFiles(fileDir);
    
        //Loop through all the file paths and read what's in there
        for (int i = 0; i < filePath.Length; i++)
        {
            if ((i + 1) % 5 == 0)
            {
                yield return null;// Wait for a frame every after 5 file read
            }
    
            BinaryFormatter loadData = new BinaryFormatter();
            FileStream dataFile = File.Open(filePath[i], FileMode.Open); //Open File
            playerData pData = (playerData)loadData.Deserialize(dataFile);
            dataFile.Close();
    
            name_O = pData.name;
            job_O = pData.job;
            difficulty_O = pData.difficulty;
    
            rawAPD = name_O + "/" + job_O.ToString() + "/" + difficulty_O.ToString();
        }
    }
