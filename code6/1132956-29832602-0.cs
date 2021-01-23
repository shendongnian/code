    PlayerObject player = new PlayerObject();
    string[] allLines = System.IO.File.ReadAllLines(FILE_PATH_HERE);
    foreach(string dataPair in allLines)
    {
        string[] pair = dataPair.Split(new[] { ':' });
        if(pair.Length == 2)
        {
            switch(pair[0])
            {
                case "Player name": /*process pair[1]*/ break;
                case "Speed": /*process pair[1]*/ break;
                //other possible key strings here
                //recommend defining these as constants
            }
        }
    }
