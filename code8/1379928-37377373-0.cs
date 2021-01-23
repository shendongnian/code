    List<string> tamerList = new List<string>();
    foreach(string tamerDino in listOfNamesAndDinos)
    {
        string tamerName = tamerDino.Split("-")[0].Trim();
        if(!tamerList.Contains(tamerName))
        {
            tamerList.Add(tamerName);
        }
    }
    //Create tabs using each name from list of tamers
    foreach(string tamer in tamerList)
    {
        List<string> fullDinosForTamer = listOfNamesAndDinos.Where(e => e.StartsWith(tamer)).ToList();
        //Populate your panel with the newly found dinos
    }
