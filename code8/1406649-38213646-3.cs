    IEnumerator loadData2()
    {
        string fileDir = Application.persistentDataPath;
        int APDIndex = 0; //Only incremented if file exist
    
        APD = new string[numOfSaveFile_O];
        loadNum = 0; //File starts at 0
        while (loadNum < numOfSaveFile_O)
        {
            string filePath = fileDir + "/data[" + loadNum + "].octa";
    
            if (File.Exists(filePath))
            {
                Debug.Log(loadNum);
    
                BinaryFormatter loadData = new BinaryFormatter();
                FileStream dataFile = File.Open(filePath, FileMode.Open); //Open File
                playerData pData = (playerData)loadData.Deserialize(dataFile);
                dataFile.Close();
    
                name_O = pData.name;
                job_O = pData.job;
                difficulty_O = pData.difficulty;
    
                rawAPD = name_O + "/" + job_O.ToString() + "/" + difficulty_O.ToString();
                APD[APDIndex] = rawAPD;
                APDIndex++;
            }
            loadNum++;
            yield return null; //Don't freeze Unity
        }
    }
